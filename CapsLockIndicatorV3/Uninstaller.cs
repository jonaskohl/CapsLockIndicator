using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    /// <summary>
    /// Removes CapsLock Indicator from the computer: autostart entry, settings,
    /// and (via a helper process that waits for this process to exit) the
    /// program's own files.
    /// </summary>
    internal static class Uninstaller
    {
        [DllImport("user32.dll")]
        private static extern bool AllowSetForegroundWindow(int dwProcessId);
        private const int ASFW_ANY = -1;

        private static readonly string[] IconFileNames =
            new[] { "caps", "num", "scroll" }.SelectMany(n => new[] { n + "0.ico", n + "1.ico" }).ToArray();

        private static string SettingsDirectory =>
            Environment.ExpandEnvironmentVariables(@"%appdata%\Jonas Kohl\CapsLock Indicator");

        /// <summary>
        /// Runs the uninstallation. Returns true if the application should now exit.
        /// </summary>
        public static bool Run(IWin32Window owner)
        {
            if (MessageBox.Show(owner, strings.uninstallConfirmation, "CapsLock Indicator",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return false;

            var exePath = Assembly.GetExecutingAssembly().Location;
            var exeDir = Path.GetDirectoryName(exePath);

            // Never write settings again, otherwise they would be recreated on exit
            SettingsManager.SavingDisabled = true;

            AutostartManager.Remove();
            DeleteSettings();

            var programFilesRemoved = IsDirectoryWritable(exeDir) && StartDeferredDelete(exePath, exeDir);

            // If the helper was started, exit right away without showing anything:
            // the helper reports the result itself. Any user input in between (e.g.
            // clicking OK on a message box here) would revoke the helper's permission
            // to come to the foreground and its message box would open in the background.
            if (!programFilesRemoved)
            {
                MessageBox.Show(owner, string.Format(strings.uninstallManualDelete, exePath), "CapsLock Indicator",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                try { Process.Start("explorer.exe", "/select,\"" + exePath + "\""); }
                catch (Win32Exception) { }
            }

            return true;
        }

        private static void DeleteSettings()
        {
            try
            {
                if (Directory.Exists(SettingsDirectory))
                    Directory.Delete(SettingsDirectory, true);

                // Remove the "Jonas Kohl" parent folder too, but only if nothing else is in it
                var parent = Path.GetDirectoryName(SettingsDirectory);
                if (Directory.Exists(parent) && !Directory.EnumerateFileSystemEntries(parent).Any())
                    Directory.Delete(parent);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException) { }
        }

        private static bool IsDirectoryWritable(string dir)
        {
            try
            {
                var probe = Path.Combine(dir, "~cli-write-test-" + Guid.NewGuid().ToString("N"));
                File.WriteAllText(probe, "");
                File.Delete(probe);
                return true;
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                return false;
            }
        }

        /// <summary>
        /// Starts a hidden helper process that waits for this process to exit and
        /// then deletes only the files that belong to CapsLock Indicator (never the
        /// whole folder, which may be e.g. the Downloads folder).
        /// </summary>
        private static bool StartDeferredDelete(string exePath, string exeDir)
        {
            var files = new List<string> { exePath };
            files.Add(Path.Combine(exeDir, "usercfg")); // portable settings
            files.Add(Path.Combine(exeDir, DownloadDialog.BAK_NAME));
            files.AddRange(IconFileNames.Select(n => Path.Combine(exeDir, n)));

            // Translation folders: delete our DLL, then the folder only if it is empty
            var emptyDirs = new List<string>();
            try
            {
                foreach (var dir in Directory.GetDirectories(exeDir))
                {
                    var dll = Path.Combine(dir, LanguageDownloadProgressForm.DLL_NAME);
                    if (File.Exists(dll))
                    {
                        files.Add(dll);
                        emptyDirs.Add(dir);
                    }
                }
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException) { }

            // Staged translation updates: this folder is entirely ours
            var recursiveDirs = new List<string> { Path.Combine(exeDir, LanguageDownloadProgressForm.DLL_UPDATE_DIR) };

            var pid = Process.GetCurrentProcess().Id;

            // We are the foreground app right now; let the helper bring its
            // completion message box to the front later
            AllowSetForegroundWindow(ASFW_ANY);

            return TryStartPowerShell(pid, files, emptyDirs, recursiveDirs)
                || TryStartCmd(files, emptyDirs, recursiveDirs);
        }

        private static bool TryStartPowerShell(int pid, List<string> files, List<string> emptyDirs, List<string> recursiveDirs)
        {
            string PsString(string s) => "'" + s.Replace("'", "''") + "'";
            string PsList(IEnumerable<string> items) => "@(" + string.Join(",", items.Select(PsString)) + ")";

            var script = new StringBuilder();
            script.AppendLine("$ErrorActionPreference = 'SilentlyContinue'");
            script.AppendLine("Wait-Process -Id " + pid);
            script.AppendLine("$files = " + PsList(files));
            script.AppendLine("$emptyDirs = " + PsList(emptyDirs));
            script.AppendLine("$recursiveDirs = " + PsList(recursiveDirs));
            // Retry a few times in case a file is still briefly locked (e.g. by antivirus)
            script.AppendLine("for ($i = 0; $i -lt 10; $i++) {");
            script.AppendLine("  $files | Where-Object { Test-Path -LiteralPath $_ } | ForEach-Object { Remove-Item -LiteralPath $_ -Force }");
            script.AppendLine("  $recursiveDirs | Where-Object { Test-Path -LiteralPath $_ } | ForEach-Object { Remove-Item -LiteralPath $_ -Recurse -Force }");
            script.AppendLine("  if (-not (@($files + $recursiveDirs) | Where-Object { Test-Path -LiteralPath $_ })) { break }");
            script.AppendLine("  Start-Sleep -Milliseconds 500");
            script.AppendLine("}");
            script.AppendLine("$emptyDirs | Where-Object { (Test-Path -LiteralPath $_) -and -not (Get-ChildItem -LiteralPath $_ -Force) } | ForEach-Object { Remove-Item -LiteralPath $_ -Force }");

            // Report the result. $files[0] is the program file itself.
            // The helper process has no window of its own, so a normal message box would
            // open behind other windows. WScript.Shell.Popup passes the flags straight to
            // MessageBox: 0x40000 = MB_TOPMOST, 0x10000 = MB_SETFOREGROUND,
            // 0x40 = information icon, 0x30 = warning icon.
            script.AppendLine("if (Test-Path -LiteralPath $files[0]) {");
            script.AppendLine("  $text = " + PsString(string.Format(strings.uninstallManualDelete, files[0])) + "; $icon = 0x30; $wfIcon = 'Warning'");
            script.AppendLine("} else {");
            script.AppendLine("  $text = " + PsString(strings.uninstallComplete) + "; $icon = 0x40; $wfIcon = 'Information'");
            script.AppendLine("}");
            script.AppendLine("try {");
            script.AppendLine("  [void](New-Object -ComObject WScript.Shell).Popup($text, 0, 'CapsLock Indicator', $icon -bor 0x40000 -bor 0x10000)");
            script.AppendLine("} catch {");
            // Fallback if Windows Script Host is disabled: DefaultDesktopOnly also shows it on top
            script.AppendLine("  Add-Type -AssemblyName System.Windows.Forms");
            script.AppendLine("  [void][System.Windows.Forms.MessageBox]::Show($text, 'CapsLock Indicator', 'OK', $wfIcon, 'Button1', 'DefaultDesktopOnly')");
            script.AppendLine("}");

            var encoded = Convert.ToBase64String(Encoding.Unicode.GetBytes(script.ToString()));

            return TryStart("powershell.exe", "-NoProfile -NonInteractive -WindowStyle Hidden -EncodedCommand " + encoded);
        }

        // Fallback if PowerShell is unavailable or blocked: wait a few seconds, then delete
        private static bool TryStartCmd(List<string> files, List<string> emptyDirs, List<string> recursiveDirs)
        {
            string Q(string p) => "\"" + p + "\"";

            var commands = new List<string> { "ping 127.0.0.1 -n 4 >nul" };
            commands.AddRange(files.Select(f => "del /f /q " + Q(f)));
            commands.AddRange(recursiveDirs.Select(d => "rd /s /q " + Q(d)));
            commands.AddRange(emptyDirs.Select(d => "rd " + Q(d))); // rd without /s only removes empty folders

            return TryStart("cmd.exe", "/c " + string.Join(" & ", commands) + " 2>nul");
        }

        private static bool TryStart(string fileName, string arguments)
        {
            try
            {
                var psi = new ProcessStartInfo(fileName, arguments)
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    // Don't keep the program folder in use as the working directory
                    WorkingDirectory = Path.GetTempPath()
                };
                Process.Start(psi)?.Dispose();
                return true;
            }
            catch (Win32Exception)
            {
                return false;
            }
        }
    }
}
