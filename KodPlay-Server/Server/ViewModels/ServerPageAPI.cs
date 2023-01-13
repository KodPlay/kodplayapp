using Furion.DatabaseAccessor.Extensions;
using Furion.DynamicApiController;
using KodPlay_Server.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KodPlay_Server.Server.ViewModels
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerPageAPI : IDynamicApiController
    {
        /// <summary>
        /// 查询在线服务器数量
        /// </summary>
        /// <returns>返回在线服务器数量(int)</returns>
        public string ServerCount()
        {

            var dataTable = "select * from sb_servers".SqlQuery();
            string data = dataTable.ToString(); 
            return data;
        }

        public string GetOnlionPersonCount()
        {
            return "修改成功";
        }

        public string GetBanPersonCount()
        {
            return "删除成功";
        }



    }
}
    