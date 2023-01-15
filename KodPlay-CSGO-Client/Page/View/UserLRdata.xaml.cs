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
    /// UserLRdata.xaml 的交互逻辑
    /// </summary>
    public partial class UserLRdata
    {
        public UserLRdata()
        {
            InitializeComponent();
            Loaded += UserLRdata_Loaded;
        }

        private void UserLRdata_Loaded(object sender, RoutedEventArgs e)
        {
            string Community_LR = string.Format("https://login.kodplay.com/profiles/{0}/0", KodPlay_CSGO_Client.Services.Control.Control_Steam_Login_Data.SteamID);
            LRWeb.Source = new Uri(Community_LR);

        }

        private void LRWeb_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {

            if (LRWeb.CoreWebView2 != null)
            {
                //LRWeb.CoreWebView2.Navigate(Community_LR);


                var path = AppDomain.CurrentDomain.BaseDirectory + "WebViewCache";

                LRWeb.CoreWebView2.Settings.AreDevToolsEnabled = false;//禁用DevTools 窗口
                LRWeb.CoreWebView2.Settings.IsZoomControlEnabled = false;//禁用缩放
                LRWeb.CoreWebView2.Settings.IsStatusBarEnabled = false;//禁用状态栏

                LRWeb.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;//注册新窗口事件

            }

        }


        private void CoreWebView2_NewWindowRequested(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NewWindowRequestedEventArgs e)
        {
            e.NewWindow = LRWeb.CoreWebView2;
        }
    }
}
