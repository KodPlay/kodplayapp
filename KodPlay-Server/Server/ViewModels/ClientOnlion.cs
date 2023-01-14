using Furion.DynamicApiController;
using Furion.InstantMessaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MySqlX.XDevAPI;

namespace KodPlay_Server.Server.ViewModels
{
    [MapHub("/hubs/onlionhub")]
    public class OnlionHub : Hub
    {
        // 定义一个方法供客户端调用
        public Task SendMessage(string user, string message)
        {
            // 触发客户端定义监听的方法
            return Clients.All.SendAsync("ReceiveMessage", user, message);
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


    public class UserIdProvider : IUserIdProvider
    {
        public virtual string GetUserId(HubConnectionContext connection)
        {
            // 你如何获取 UserId，可以通过 connection.User 获取 JWT 授权的用户
            return connection.User.ToString();
        }
    }
}
