using Furion.DynamicApiController;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace KodPlay_Server.Server.ViewModels
{
    public class ClientOnlionApi : Controller
    {

        private readonly IHubContext<OnlionHub> _hubContext;

        public ClientOnlionApi(IHubContext<OnlionHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task<IActionResult> Index()
        {
            await _hubContext.Clients.All.SendAsync("Notify", $"Home page loaded at: {DateTime.Now}");
            return View();
        }

    }
}
