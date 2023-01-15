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
using Wpf.Ui.Controls;

namespace KodPlay_CSGO_Client
{
    /// <summary>
    /// store.xaml 的交互逻辑
    /// </summary>
    public partial class Store : UiPage
    {
        public Store()
        {
            InitializeComponent();
        }

        private void StoreWeb_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            if (StoreWeb.CoreWebView2 != null)
            {
                StoreWeb.CoreWebView2.Navigate("https://game.kodplay.com/store");

                //设置请求UA
                StoreWeb.CoreWebView2.Settings.UserAgent = "kod";


                var path = AppDomain.CurrentDomain.BaseDirectory + "WebViewCache";

                StoreWeb.CoreWebView2.Settings.AreDevToolsEnabled = false;//禁用DevTools 窗口
                StoreWeb.CoreWebView2.Settings.IsZoomControlEnabled = false;//禁用缩放
                StoreWeb.CoreWebView2.Settings.IsStatusBarEnabled = false;//禁用状态栏

                StoreWeb.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;//注册新窗口事件

            }
        }

        private void CoreWebView2_NewWindowRequested(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NewWindowRequestedEventArgs e)
        {
            e.NewWindow = StoreWeb.CoreWebView2;
        }
    }
}
