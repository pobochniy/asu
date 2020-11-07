using Atheneum.Enums;

namespace Atheneum.Dto.Chat
{
    public class SysMessagesDto
    {
        public ChatTypeEnum Type { get; set; }

        public object Data { get; set; }
    }
}
