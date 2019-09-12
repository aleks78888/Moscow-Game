using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using CefSharp.Handler;
namespace Moscow
{


    public partial class Form1 : Form
        {
        public ChromiumWebBrowser chrome;
            public void InitChrome()
            {
                CefSettings settings = new CefSettings();

            string path = System.IO.Directory.GetCurrentDirectory().ToString() + @"\cook";
            settings.RemoteDebuggingPort = 8080;
            settings.CachePath = path;
            Cef.Initialize(settings);
               CefSharpSettings.LegacyJavascriptBindingEnabled = true;

            //  chrome = new ChromiumWebBrowser("https://upread.ru/art.php?id=214");
          chrome = new ChromiumWebBrowser("http://moscow.hurtworld.pro/");
            chrome.DownloadHandler = new DownloadHandler(progressBar1);
                panel1.Controls.Add(chrome);
                chrome.Dock = DockStyle.Fill;
                ChromiumLifeSpanHandler life = new ChromiumLifeSpanHandler();
                chrome.LifeSpanHandler = life;
                chrome.LoadingStateChanged += OnLoadingStateChanged;
            //chrome.ExecuteScriptAsync("$(document).click(function(event) {var text = $(event.target).text(); alert(text);});");
       

 
        }

            public Form1()
            {
                InitializeComponent();
            }

            private void Form1_Load(object sender, EventArgs e)
            {
                //  webBrowser1.Url = new Uri("http://moscow.hurtworld.pro/");
                //webBrowser1.ScriptErrorsSuppressed = true;
                InitChrome();
            }

            private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
            {
                if (!args.IsLoading)
            {
   // chrome.ExecuteScriptAsyncWhenPageLoaded("$('a[target=\"_blank\"]').each(function(i, elem) {($(elem).attr('href', $(elem).attr('href') + 'vvvvv'));}); jQuery('a').attr('target', '_blank'); ");
chrome.ExecuteScriptAsyncWhenPageLoaded("var tsts; if (tsts != 5) {var tsts=5; jQuery('a').each(function(i, elem) {if ($(elem).attr('target') == '_blank') $(elem).attr('href', $(elem).attr('href') + 'vvvvv');else $(elem).attr('target', '_blank');}); }");
              
//chrome.ExecuteScriptAsync("");

                //  chrome.ExecuteScriptAsync("$(document).click(function(event) {var text = $(event.target).text(); alert(text);});");
            }
        }

            private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {


            }

            private void button1_Click(object sender, EventArgs e)
            {

                // System.Diagnostics.Process.Start("CatchFocus.exe");
            }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    }

