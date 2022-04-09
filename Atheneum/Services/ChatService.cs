using Atheneum.Dto.Chat;
using Atheneum.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atheneum.Entity;

namespace Atheneum.Services
{
    public class ChatService : IChatService
    {
        private ApplicationContext db;

        public ChatService(ApplicationContext context)
        {
            db = context;
        }

        public async Task<Guid?> SavePrivateMsg(Guid senderId, string receiverName, ChatDto msg)
        {
            var receiver = await db.Profiles.FirstOrDefaultAsync(x => x.UserName == receiverName);
            if (receiver != null)
            {
                var model = new ChatPrivate
                {
                    Tick = DateTime.UtcNow.Ticks,
                    SenderId = senderId,
                    ReceiverId = receiver.Id,
                    Type = msg.Type,
                    Login = msg.Login,
                    Privat = String.Join("#", msg.Privat),
                    Msg = msg.Message
                };
                if (msg.To.Count() > 0) model.To = string.Join("#", msg.To);

                await db.ChatPrivate.AddAsync(model);
                await db.SaveChangesAsync();

                return receiver.Id;
            }

            return null;
        }

        public async Task SaveRoomMsg(Guid senderId, ChatDto msg)
        {
            // TODO : добавить комнаты

            var model = new ChatRoom
            {
                Id = DateTime.UtcNow.Ticks,
                Room = Enums.RoomEnum.main,
                Type = msg.Type,
                Login = msg.Login,
                Msg = msg.Message
            };
            if (msg.To.Count() > 0) model.To = string.Join("#", msg.To);

            await db.ChatRoom.AddAsync(model);
            await db.SaveChangesAsync();
        }

        public Task<IEnumerable<ChatDto>> GetLastMessages(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
