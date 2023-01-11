using Furion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodPlay_Server.Server.Other.Dev
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherServer : ControllerBase
    {
        [HttpGet("ServerInfo/DevInfo")]
        public string Get()
        {
            return $@"名称：{App.Configuration["AppInfo:Name"]}，
                      版本：{App.Configuration["AppInfo:Version"]}，
                      开发者：{App.Configuration["AppInfo:DevAuthor"]}";
        }
    }
}
