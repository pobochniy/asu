using Atheneum.Dto.Chat;
using Atheneum.Extentions.Auth;
using Atheneum.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using Web.SignalR;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private readonly IChatService service;
        private readonly IHubContext<ChatHub, IChatHub> _hub;

        public ChatController(IChatService service, IHubContext<ChatHub, IChatHub> hubContext)
        {
            this.service = service;
            this._hub = hubContext;
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public async Task<IActionResult> GetLastMessages()
        {
            var msgs = await service.GetLastMessages(User.GetUserId());

            return Ok(msgs);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Push([FromBody] ImageModel dto)//([FromBody]string file)//
        {
            //var model = new ChatDto
            //{
            //    Login = "rpi",
            //    Id = DateTime.Now.Ticks + "",
            //    Type = Atheneum.Enums.ChatTypeEnum.text,
            //    Message = "img time received = " + dto.Time
            //};

            //await _hub.Clients.All.BroadCastMessage(model);
            await _hub.Clients.All.BroadCastImage(dto);
            return Ok();
        }
    }

}
