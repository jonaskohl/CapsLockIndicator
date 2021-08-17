using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapsLockIndicatorV3
{
    public static class DarkModeProvider
    {
        public static bool IsDark => SystemSupportsDarkMode && SettingsManager.Get<bool>("darkMode");
        public static bool SystemSupportsDarkMode => Environment.OSVersion.Version.Major >= 10;

        private static List<DarkModeForm> registeredForms = new List<DarkModeForm>();

        public static void RegisterForm(DarkModeForm form)
        {
            registeredForms.Add(form);
            form.FormClosing += Form_FormClosing;
            form.OnDarkModeChanged();
        }

        public static void SetDarkModeEnabled(bool enabled)
        {
            SettingsManager.Set("darkMode", enabled);
            UpdateForms();
        }

        private static void UpdateForms()
        {
            foreach (var f in registeredForms)
                f.OnDarkModeChanged();
        }

        private static void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            registeredForms.Remove(sender as DarkModeForm);
        }
    }
}
