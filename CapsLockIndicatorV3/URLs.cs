namespace CapsLockIndicatorV3
{
    static class URLs
    {
        public const string MainWebsite = "https://github.com/wowwon/ImeModeIndicator/";
        public const string ProjectWebsite = "https://github.com/wowwon/ImeModeIndicator/";
        public const string GithubRepo = "https://github.com/wowwon/ImeModeIndicator/";

        public const string ServiceEndpointBase = "";

        public const string DownloadTranslations = ProjectWebsite + "!/translations#download-translations";

        public const string LangServiceUrl = ServiceEndpointBase + "!/langservice";
        public const string KBUpdateCheck = ServiceEndpointBase + "kb/?a=updatecheck";
        public const string IconGalleryMeta = ServiceEndpointBase + "icongallery/getmeta.php";
        public const string IconGalleryDownload = ServiceEndpointBase + "icongallery/";
        public const string IconGallery = ServiceEndpointBase + "icongallery/embedded.php";
        public const string ClientSupported = ServiceEndpointBase + "eolcheck";
        public const string VersionCheck = ServiceEndpointBase + "!/version?details&xml&newClient3=true";
    }
}
