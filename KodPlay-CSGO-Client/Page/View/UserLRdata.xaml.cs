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
            LR.Source = new Uri(Community_LR);
        }
    }
}
