using Furion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodPlay_Server.Server.Other.Dev
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherServer : ControllerBase
    {javascript:void(0);
        [HttpGet("ServerInfo/DevInfo")]
        public string Get()
        {
            return $@"名称：{App.Configuration["AppInfo:Name"]}，
                      版本：{App.Configuration["AppInfo:Version"]}，
                      开发者：{App.Configuration["AppInfo:DevAuthor"]}";
        }
    }
}
