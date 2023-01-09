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
    /// Server.xaml 的交互逻辑
    /// </summary>
    public partial class Server
    {
        public Server()
        {
            InitializeComponent();
            Loaded += Server_Loaded;
        }

        private void Server_Loaded(object sender, RoutedEventArgs e)
        {
            KodPlay_CSGO_Client.Services.Analysis_Userdata.Analysis_Userdata.Analysis_Userdata_handinfoAsync();
        }

        private void Server_Model_Set(object sender, RoutedEventArgs e)
        {

        }

        private void GetCsgoPath(object sender, RoutedEventArgs e)
        {

        }

        private void CommunityServerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CloseContionlHC(object sender, RoutedEventArgs e)
        {

        }

        private void ActionConnect(object sender, RoutedEventArgs e)
        {

        }
    }
}
