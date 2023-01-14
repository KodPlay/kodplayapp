using Furion.DynamicApiController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using System.Web;

namespace KodPlay_Server.Server.Other
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessDownloadApi : IDynamicApiController
    {
        [HttpGet, NonUnify]
        public IActionResult FileDownload(string AccessName)
        {
            string filePath = "Resources\\"+ AccessName;
            return new FileStreamResult(new FileStream(filePath, FileMode.Open), "application/octet-stream")
            {
                FileDownloadName = AccessName // 配置文件下载显示名
            };
        }


    }
}
