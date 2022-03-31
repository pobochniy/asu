using Microsoft.AspNetCore.SignalR;
using Atheneum.Interface;
using Atheneum.Dto.Chat;
using Microsoft.AspNetCore.Authorization;

namespace Api.SignalR
{
    public class ChatHub : Hub<IChatHub>
    {
        private readonly IChatService service;

        public ChatHub(IChatService service)
        {
            this.service = service;
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

            if (msg.Privat.Any())
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
            await this.service.SaveRoomMsg(Guid.Parse(this.Context.UserIdentifier), msg);
            await this.Clients.All.BroadCastMessage(msg);
        }

        private async Task SendPrivate(ChatDto msg)
        {
            var receiverList = msg.Privat.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

            if (!receiverList.Contains(msg.Login))
                receiverList.Add(msg.Login);

            foreach (var el in receiverList)
            {
                try
                {
                    var receiverId = await service.SavePrivateMsg(Guid.Parse(this.Context.UserIdentifier), el, msg);
                    if (receiverId.HasValue) await this.Clients.User(receiverId.ToString()).BroadCastMessage(msg);
                }
                catch
                {
                }
            }
        }
    }
}