using Atheneum.Dto.Chat;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atheneum.Interface
{
    public interface IChatHub
    {
        /// <summary>
        /// С сервера на все клиенты
        /// </summary>
        Task BroadCastMessage(ChatDto msg);

        /// <summary>
        /// Рассылка системных сообщений
        /// </summary>
        Task SysMessages(SysMessagesDto dtoS);

        Task PushMessage(PushChatDto msg);

        Task SendUsers(List<string> usersOnline);
    }
}
