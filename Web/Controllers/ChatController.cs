using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Atheneum.Interface;
using Atheneum.Dto.Chat;
using Microsoft.AspNetCore.SignalR;
using Web.SignalR;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        //private IHubContext<ChatHub, IChatHub> _hub;

        //public ChatController(IHubContext<ChatHub, IChatHub> hubContext)
        //{
        //    this._hub = hubContext;
        //}


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Send([FromBody]PushChatDto model)
        {
            var user = User?.Identity?.Name ?? "null";
            string time = DateTime.Now.ToString("HH:mm");
            string mesage = $"[{user}] [{time}]: {model?.Message ?? ""}";
            //await _hub.Clients.All.BroadCastMessage(mesage);

            return Ok();
        }
    }
}
