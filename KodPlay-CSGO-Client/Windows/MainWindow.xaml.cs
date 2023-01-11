using KodPlay_CSGO_Client.Services.AutoUpdata;
using KodPlay_CSGO_Client.Services.ProcessStartRun;
using KodPlay_CSGO_Client.Services.steaminfo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (ProcessStartRun.Cheak_Process_In_Run()) //先检测Steam是否在线
            {
                using (var steam = new SteamBridge())
                    KodPlay_CSGO_Client.Services.Control.Control_Steam_Login_Data.SteamID = steam.GetSteamId();//获取SteamID
            }
            else
            {
                MessageBox.Show("请打开Steam,并重启软件");
                Process.GetCurrentProcess().Kill();
            }

            //注册服务
            AutoUpdata.Client_Update(); //自动更新服务
            

        }
    }
}
