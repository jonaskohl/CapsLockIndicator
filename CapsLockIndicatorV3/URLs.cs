namespace CapsLockIndicatorV3
{
    static class URLs
    {
        public const string MainWebsite = "https://jonaskohl.de/";
        public const string ProjectWebsite = "https://cli.jonaskohl.de/";
        public const string GithubRepo = "https://github.com/jonaskohl/CapsLockIndicator";

        public const string ServiceEndpointBase = ProjectWebsite;

        public const string DownloadTranslations = ProjectWebsite + "!/translations#download-translations";

        public const string LangServiceUrl = ServiceEndpointBase + "!/langservice";
        public const string KBUpdateCheck = ServiceEndpointBase + "kb/?a=updatecheck";
        public const string IconGalleryMeta = ServiceEndpointBase + "icongallery/getmeta.php";
        public const string IconGalleryDownload = ServiceEndpointBase + "icongallery/";
        public const string IconGallery = ServiceEndpointBase + "icongallery/embedded.php";
        public const string ClientSupported = ServiceEndpointBase + "clientsupported";
        public const string VersionCheck = ServiceEndpointBase + "!/version?details&xml&newClient3=true";
    }
}
