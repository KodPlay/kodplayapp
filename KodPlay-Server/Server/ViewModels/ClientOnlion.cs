using Furion.DynamicApiController;
using Furion.InstantMessaging;
using KodPlay_Server.Control.Data.SignalRClientInfo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MySqlX.XDevAPI;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Security.Authentication;

namespace KodPlay_Server.Server.ViewModels
{
    [MapHub("/hubs/onlionhub")]
    public class OnlionHub : Hub
    {

        static long counter = 0;//在线人数

        // 定义一个方法供客户端调用
        public Task SendMessage(string user, string message)
        {
            // 触发客户端定义监听的方法
            return Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override System.Threading.Tasks.Task OnConnectedAsync()
        {
            counter = counter + 1;


            SignalRClientInfo signalRClientInfo = new SignalRClientInfo
            {
                ClientName = Context.ConnectionId
            };


            Console.WriteLine("客户端连接成功,ID："+ Context.ConnectionId + "目前已有"+ counter+"连接成功");
            Clients.All.SendAsync("updateCount", counter);
            return base.OnConnectedAsync();
        }

        public override System.Threading.Tasks.Task OnDisconnectedAsync(Exception? exception)
        {
            counter = counter - 1;
            Console.WriteLine("客户端断开连接,ID：" + Context.ConnectionId + "目前在线人数" + counter);
            Clients.All.SendAsync("updateCount", counter);
            return base.OnDisconnectedAsync(exception);
        }


        public static void HttpConnectionDispatcherOptionsSettings(HttpConnectionDispatcherOptions options)
        {
            // 配置
        }

        public static void HubEndpointConventionBuilderSettings(HubEndpointConventionBuilder Builder)
        {
            // 配置
        }
    }



}
