using Atheneum.Enums;

namespace Atheneum.Dto.Chat
{
    public class ChatDto : PushChatDto
    {
        public string Id { get; set; }

        public ChatTypeEnum Type { get; set; }

        public string Login { get; set; }
    }
}
