using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Atheneum.Dto.Auth
{
    public class UserDto
    {
        [JsonIgnore]
        public Guid UserId { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
