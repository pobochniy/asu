using System.Collections.Generic;

namespace Atheneum.Dto.Chat
{
    public class PushChatDto
    {
        public PushChatDto()
        {
            To = new string[] { };
            Privat = new string[] { };
        }

        public string Message { get; set; }

        public IEnumerable<string> To { get; set; }

        public IEnumerable<string> Privat { get; set; }
    }
}
