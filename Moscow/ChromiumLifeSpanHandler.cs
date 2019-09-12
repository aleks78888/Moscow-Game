using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moscow
{//C:\Users\Tom\Desktop\Moscow7z\Moscow\Properties\Settings.settings
    public class ChromiumLifeSpanHandler : ILifeSpanHandler
    {

        public bool DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            return false;
        }

        public void OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
           
        }

        public void OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {

        }

        public bool OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null;
              if (targetUrl.Contains("play788hurtworld")) 
            {
                System.Diagnostics.Process.Start(@"hurtworldv2\hurtworld.exe");
            }

            else if (targetUrl.Contains("play788rustlegacy"))
            {
                System.Diagnostics.Process.Start(@"C:\Games\Release\Rust3\RustClient.exe");
            }

            else if (targetUrl.Contains("play788rustexpir"))
            {
                System.Diagnostics.Process.Start(@"C:\Games\Release\Rust3");
            }

            else if (targetUrl.Contains("play788cheatalkad"))
            {
                System.Diagnostics.Process.Start(@"RustExp\Alkad.exe");
            }


            else
            {
                if (targetUrl.Contains("vvvvv"))
                {
                    string tu2 = targetUrl.Replace("vvvvv", "");
                    System.Diagnostics.Process.Start(tu2);
                }
                else
                {
                    string tu2 = targetUrl.Replace("vvvvv", "");
                    chromiumWebBrowser.ExecuteScriptAsync("window.location = '"+ tu2 + "';");
                }
            }
            return true;
        }
    }
}
