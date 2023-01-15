using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KodPlay_CSGO_Client.Services
{
    public class ServerSignalR
    {
        HubConnection connection;

        public async void ConnectServer()
        {
            connection = new HubConnectionBuilder()
               .WithUrl("http://localhost:5000/hubs/onlionhub")
               .WithAutomaticReconnect()   
               .Build();

            try
            {
                // подключемся к хабу
                await connection.StartAsync();
                //MessageBox.Show("服务器连接成功");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
