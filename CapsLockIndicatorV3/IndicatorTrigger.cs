using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapsLockIndicatorV3
{
    public struct IndicatorTrigger
    {
        public IndicatorKey Key;
        public bool NewState;
        public string DisplayText;

        public static bool ShowInfinite(IndicatorTrigger trigger)
        {
            if (trigger.Key == IndicatorKey.None)
                return false;

            var keyName = "persistentOverlay" + trigger.Key.ToString() + (trigger.NewState ? "On" : "Off");
            return SettingsManager.Get<bool>(keyName);
        }
    }

    public enum IndicatorKey
    {
        None,
        Caps,
        Num,
        Scroll,
        Keyboard
    }
}
