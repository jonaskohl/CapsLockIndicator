using System;

namespace CapsLockIndicatorV3
{
    [Serializable]
    struct DropDownLocale
    {
        public string displayText;
        public string localeString;

        public DropDownLocale(string localeString)
        {
                 displayText  = localeString;
            this.localeString = localeString;
        }

        public DropDownLocale(string localeString, string displayText)
        {
            this.displayText  = displayText;
            this.localeString = localeString;
        }

        public override string ToString()
        {
            return $"{displayText}";
        }
    }
}
