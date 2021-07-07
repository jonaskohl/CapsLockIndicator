using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CapsLockIndicatorV3
{
    [ComVisible(true)]
    public class IconGalleryObjectForScripting
    {
        internal event EventHandler<string> OnDownloadRequested;
        internal event EventHandler OnCloseWindowRequested;

        public void downloadPack(string id)
        {
            OnDownloadRequested?.Invoke(this, id);
        }

        public void openExternalLink(string url)
        {
            if (!url.StartsWith("http://") && !url.StartsWith("https://")) // unsafe url
                return;

            Process.Start(url);
        }

        public void closeWindow()
        {
            OnCloseWindowRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
