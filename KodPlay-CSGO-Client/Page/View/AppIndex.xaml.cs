using Microsoft.Web.WebView2.Core;
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
    /// AppIndex.xaml 的交互逻辑
    /// </summary>
    public partial class AppIndex
    {
        public AppIndex()
        {
            InitializeComponent();
            Loaded += AppIndex_Loaded;
        }

        private void AppIndex_Loaded(object sender, RoutedEventArgs e)
        {
            //AppIndexWeb.CoreWebView2.ExecuteScriptAsync("window.addEventListener('contextmenu', window => {window.preventDefault();});");
        }

        private void AppIndexWeb_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            if (AppIndexWeb.CoreWebView2 != null)
            {
                AppIndexWeb.CoreWebView2.Navigate("https://kodplay.com/app.html");

                //设置请求UA
                //AppIndexWeb.CoreWebView2.Settings.UserAgent = "kod";
               

                var path = AppDomain.CurrentDomain.BaseDirectory + "WebViewCache";
                AppIndexWeb.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;//禁用右键菜单
                AppIndexWeb.CoreWebView2.Settings.AreDevToolsEnabled = false;//禁用DevTools 窗口
                AppIndexWeb.CoreWebView2.Settings.IsZoomControlEnabled = false;//禁用缩放
                AppIndexWeb.CoreWebView2.Settings.IsStatusBarEnabled = false;//禁用状态栏

                AppIndexWeb.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;//注册新窗口事件

            }
        }

        private void CoreWebView2_NewWindowRequested(object? sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            e.NewWindow = AppIndexWeb.CoreWebView2;
            
        }
    }
}
