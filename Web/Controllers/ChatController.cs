﻿using Atheneum.Extentions.Auth;
using Atheneum.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private readonly IChatService service;

        public ChatController(IChatService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public async Task<IActionResult> GetLastMessages()
        {
            var msgs = await service.GetLastMessages(User.GetUserId());

            return Ok(msgs);
        }
    }
}
