using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KodPlay_CSGO_Client
{
    /// <summary>
    /// Community.xaml 的交互逻辑
    /// </summary>
    public partial class Community : Page
    {
        public Community()
        {
            InitializeComponent();
        }

        private void CommunityWeb_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            if (CommunityWeb.CoreWebView2 != null)
            {
                CommunityWeb.CoreWebView2.Navigate("https://game.kodplay.com/store");

                //设置请求UA
                CommunityWeb.CoreWebView2.Settings.UserAgent = "kod";


                var path = AppDomain.CurrentDomain.BaseDirectory + "WebViewCache";

                CommunityWeb.CoreWebView2.Settings.AreDevToolsEnabled = false;//禁用DevTools 窗口
                CommunityWeb.CoreWebView2.Settings.IsZoomControlEnabled = false;//禁用缩放
                CommunityWeb.CoreWebView2.Settings.IsStatusBarEnabled = false;//禁用状态栏

                CommunityWeb.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;

            }
        }

        private void CoreWebView2_NewWindowRequested(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NewWindowRequestedEventArgs e)
        {
            e.NewWindow = CommunityWeb.CoreWebView2;
        }
    }
}
