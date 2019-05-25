using System;
using System.Collections.Generic;
using System.Text;

namespace Atheneum.Dto.Chat
{
    public class PushChatDto
    {
        public string Message { get; set; }

        public IEnumerable<string> To { get; set; }

        public IEnumerable<string> Privat { get; set; }
    }
}
