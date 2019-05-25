using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atheneum.Interface;
using Atheneum.Dto.Chat;
using Microsoft.AspNetCore.Authorization;

namespace Web.SignalR
{
    public class ChatHub : Hub<IChatHub>
    {
        [Authorize]
        public async Task PushMessage(PushChatDto msg)
        {
            // TODO: Вызывать метод из контроллера и передавать инфу юзера

            var chatMsg = new ChatDto
            {
                Id = "0",
                Type = Atheneum.Enums.ChatTypeEnum.text,
                Login = this.Context.UserIdentifier,
                Message = msg.Message,
                Privat = msg.Privat,
                To = msg.To
            };
            

            await this.Clients.All.BroadCastMessage(chatMsg);
        }
    }
}
