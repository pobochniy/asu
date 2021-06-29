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
        private readonly IChatService service;

        public static List<string> UsersOnline = new List<string>();

        public ChatHub(IChatService service)
        {
            this.service = service;
        }

        public override Task OnConnectedAsync()
        {
            if (!UsersOnline.Contains(Context.UserIdentifier))
            {
                UsersOnline.Add(Context.UserIdentifier);
                Clients.All.SendUsers(UsersOnline);
            }

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            if (UsersOnline.Contains(Context.UserIdentifier))
            {
                UsersOnline.Remove(Context.UserIdentifier);
                Clients.All.SendUsers(UsersOnline);
            }

            return base.OnDisconnectedAsync(exception);
        }

        [Authorize]
        public async Task PushMessage(PushChatDto msg)
        {
            var chatMsg = new ChatDto
            {
                Id = DateTime.UtcNow.Ticks.ToString(),
                Type = Atheneum.Enums.ChatTypeEnum.text,
                Login = this.Context.User.Identity.Name,
                Message = msg.Message,
                Privat = msg.Privat,
                To = msg.To
            };

            if (msg.Privat.Count() > 0)
            {
                await SendPrivate(chatMsg);
            }
            else
            {
                await SendAll(chatMsg);
            }
        }

        public async Task GetUsersOnline()
        {
            await Clients.Caller.SendUsers(UsersOnline);
        }

        private async Task SendAll(ChatDto msg)
        {
            await this.service.SaveRoomMsg(Guid.Parse(this.Context.UserIdentifier), msg);
            await this.Clients.All.BroadCastMessage(msg);
        }

        private async Task SendPrivate(ChatDto msg)
        {
            List<string> receiverList = new List<string>(msg.Privat);

            if (!receiverList.Contains(msg.Login))
                receiverList.Add(msg.Login);

            foreach (var el in receiverList)
            {
                try
                {
                    var receiverId = await service.SavePrivateMsg(Guid.Parse(this.Context.UserIdentifier), el, msg);
                    if (receiverId.HasValue) await this.Clients.User(receiverId.ToString()).BroadCastMessage(msg);
                }
                catch { }
            }
        }


    }
}
