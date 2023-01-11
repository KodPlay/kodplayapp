using Furion.DynamicApiController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodPlay_Server.Server.ViewModels
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerPageAPI : IDynamicApiController
    {
        public string GetOnlionServerCount()
        {
            return $"v1.0.0";
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
    