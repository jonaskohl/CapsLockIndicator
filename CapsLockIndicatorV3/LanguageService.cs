using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CapsLockIndicatorV3
{
    /// <summary>
    /// A translation available for download from the language service.
    /// </summary>
    internal class RemoteLanguage
    {
        public string Locale { get; set; }
        public string EnglishName { get; set; }
        public DllInfo Dll { get; set; }

        /// <summary>
        /// Name for display: the native name followed by the English name,
        /// e.g. "Deutsch - German".
        /// </summary>
        public string DisplayName
        {
            get
            {
                try
                {
                    var native = CultureInfo.GetCultureInfo(Locale).NativeName;
                    return string.Equals(native, EnglishName, StringComparison.OrdinalIgnoreCase)
                        ? native
                        : native + " – " + EnglishName;
                }
                catch (CultureNotFoundException)
                {
                    return EnglishName;
                }
            }
        }
    }

    internal static class LanguageService
    {
        /// <summary>
        /// Downloads the list of translations available on the server.
        /// </summary>
        public static async Task<List<RemoteLanguage>> GetAvailableAsync()
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add(HttpRequestHeader.UserAgent, VersionCheck.UserAgent);
                var xml = await wc.DownloadStringTaskAsync(URLs.LangServiceUrl);

                return XDocument.Parse(xml).Root.Elements("lang").Select(t =>
                {
                    var locale = t.Attribute("locale").Value;
                    return new RemoteLanguage()
                    {
                        Locale = locale,
                        EnglishName = t.Attribute("displayName")?.Value ?? locale,
                        Dll = new DllInfo()
                        {
                            Filepath = URLs.LangServiceUrl + "?download=" + locale + "&as=dll",
                            SHA1 = t.Attribute("dllHashSHA1").Value,
                            Version = new Version(t.Attribute("version").Value)
                        }
                    };
                }).ToList();
            }
        }

        /// <summary>
        /// Locales of the translations installed next to the executable.
        /// </summary>
        public static HashSet<string> GetInstalledLocales()
        {
            var result = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            try
            {
                foreach (var dir in Directory.GetDirectories(exeDir))
                    if (File.Exists(Path.Combine(dir, LanguageDownloadProgressForm.DLL_NAME)))
                        result.Add(Path.GetFileName(dir));
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException) { }

            return result;
        }

        /// <summary>
        /// Finds the available translation that best matches a culture: first by exact
        /// name, then by its parent cultures (e.g. "de-DE" -> "de"), and finally by
        /// language if exactly one translation exists for it (e.g. "tr" -> "tr-TR").
        /// </summary>
        public static RemoteLanguage FindBestMatch(IEnumerable<RemoteLanguage> languages, CultureInfo culture)
        {
            var list = languages.ToList();

            for (var c = culture; c != null && !string.IsNullOrEmpty(c.Name); c = c.Parent)
            {
                var match = list.FirstOrDefault(l => string.Equals(l.Locale, c.Name, StringComparison.OrdinalIgnoreCase));
                if (match != null)
                    return match;

                if (c.Parent == c)
                    break;
            }

            var sameLanguage = list.Where(l =>
            {
                try { return CultureInfo.GetCultureInfo(l.Locale).TwoLetterISOLanguageName == culture.TwoLetterISOLanguageName; }
                catch (CultureNotFoundException) { return false; }
            }).ToList();

            return sameLanguage.Count == 1 ? sameLanguage[0] : null;
        }
    }
}
