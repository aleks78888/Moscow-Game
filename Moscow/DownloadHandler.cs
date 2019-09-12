using CefSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moscow
{
    public class DownloadHandler : IDownloadHandler
    {
        private System.Windows.Forms.ProgressBar _bar;

        public string filename = "";

        public DownloadHandler(ProgressBar bar)
        {
            _bar = bar;
        }

        public event EventHandler<DownloadItem> OnBeforeDownloadFired;

        public event EventHandler<DownloadItem> OnDownloadUpdatedFired;

        public void OnBeforeDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
      
            OnBeforeDownloadFired?.Invoke(this, downloadItem);

            if (!callback.IsDisposed)
            {
                using (callback)
                {
                    callback.Continue(downloadItem.SuggestedFileName, showDialog: false);

                }
                //     Console.WriteLine(downloadItem.SuggestedFileName);
                filename = downloadItem.SuggestedFileName;
                //System.Diagnostics.Process.Start(downloadItem.SuggestedFileName);
            }
        }

        /* public void OnDownloadUpdated(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
         {
             OnDownloadUpdatedFired?.Invoke(this, downloadItem);
         }*/

        public void OnDownloadUpdated(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {


            this._bar.Invoke(new Action(() =>
            {
                _bar.Visible = true;
                _bar.Maximum = (int)downloadItem.TotalBytes;
                _bar.Value = (int)downloadItem.ReceivedBytes;
            }));

            if (downloadItem.IsComplete)
            {
                this._bar.Invoke(new Action(() =>
                {
                    _bar.Visible = false;
                }));


              
                    try
                    {
                        System.Diagnostics.Process.Start(filename);
              

                    }
                    catch (System.InvalidOperationException se)
                    {
                    Console.WriteLine(se.ToString());
                        System.Threading.Thread.Sleep(1000);
                    //    Console.WriteLine(System.IO.Path.GetFileName(downloadItem.SuggestedFileName));
                    }

             
            }
        }
    }
}


