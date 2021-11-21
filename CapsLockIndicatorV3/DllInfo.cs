using System;

namespace CapsLockIndicatorV3
{
    public struct DllInfo
    {
        public string Filepath;
        public string SHA1;
        public Version Version;

        public override string ToString()
        {
            return "DllInfo{"
                + "Filepath=" + Filepath + ";"
                + "SHA1=" + SHA1 + ";"
                + "Version=" + Version.ToString() + "}";
        }
    }
}
