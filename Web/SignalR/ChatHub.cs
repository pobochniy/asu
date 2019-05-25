using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atheneum.Interface;
using Atheneum.Dto.Chat;

namespace Web.SignalR
{
    public class ChatHub : Hub<IChatHub>
    {
        public async Task PushMessage(PushChatDto msg)
        {
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
