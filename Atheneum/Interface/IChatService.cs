using Atheneum.Dto.Chat;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atheneum.Interface
{
    public interface IChatService
    {
        /// <summary>
        /// Сохраняем приватное сообщение
        /// </summary>
        /// <returns>UserId Получателя</returns>
        Task<Guid?> SavePrivateMsg(Guid senderId, string receiverName, ChatDto msg);

        /// <summary>
        /// Сохраняем общее сообщение в комнату
        /// </summary>
        Task SaveRoomMsg(Guid senderId, ChatDto msg);

        /// <summary>
        /// Получаем сообщения пользователя за 2 дня
        /// </summary>
        Task<IEnumerable<ChatDto>> GetLastMessages(Guid userId);
    }
}
