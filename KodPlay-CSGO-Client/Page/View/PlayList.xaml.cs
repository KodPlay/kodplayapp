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
    /// TemporaryServer.xaml 的交互逻辑
    /// </summary>
    public partial class PlayList
    {
        public PlayList()
        {
            InitializeComponent();
        }

        private void PlayList_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            if (PlayListWeb.CoreWebView2 != null)
            {
                PlayListWeb.CoreWebView2.Navigate("https://game.kodplay.com/bangdanhuizong");

                PlayListWeb.CoreWebView2.Settings.UserAgent = "kod";


                var path = AppDomain.CurrentDomain.BaseDirectory + "WebViewCache";

                PlayListWeb.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;//禁用右键菜单
                PlayListWeb.CoreWebView2.Settings.AreDevToolsEnabled = false;//禁用DevTools 窗口
                PlayListWeb.CoreWebView2.Settings.IsZoomControlEnabled = false;//禁用缩放
                PlayListWeb.CoreWebView2.Settings.IsStatusBarEnabled = false;//禁用状态栏

                PlayListWeb.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;//注册新窗口事件

            }
        }

        private void CoreWebView2_NewWindowRequested(object? sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            e.NewWindow = PlayListWeb.CoreWebView2;

        }
    }
}
