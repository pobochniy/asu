using Atheneum.Dto.Chat;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atheneum.Interface
{
    public interface IChatHub
    {
        /// <summary>
        /// С сервера на все клиенты
        /// </summary>
        Task BroadCastMessage(ChatDto msg);

        Task PushMessage(PushChatDto msg);
    }
}
