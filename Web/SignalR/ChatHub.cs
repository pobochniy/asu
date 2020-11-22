using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atheneum.Interface;
using Atheneum.Dto.Chat;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace Web.SignalR
{
    public class ChatHub : Hub<IChatHub>
    {
        private readonly IChatService service;

        public ChatHub(IChatService service)
        {
            this.service = service;
        }

        //[Authorize]
        public async Task PushMessage(PushChatDto msg)
        {
            var chatMsg = new ChatDto
            {
                Id = DateTime.UtcNow.Ticks.ToString(),
                Type = Atheneum.Enums.ChatTypeEnum.text,
                Login = "jeer",//this.Context.User.Identity.Name,
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

        private async Task SendAll(ChatDto msg)
        {
            //await this.service.SaveRoomMsg(Guid.Parse(this.Context.UserIdentifier), msg);
            if (msg.Message == "img")
            {
                byte[] file = await File.ReadAllBytesAsync(@"C:\Avatars\whatsapp.png");//user7.jpg
                //string base64String = Convert.ToBase64String(file);

               // await Clients.All.BroadCastImage(file);
            }

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
