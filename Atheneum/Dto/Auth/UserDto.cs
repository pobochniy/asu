using Atheneum.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Atheneum.Dto.Auth
{
    public class UserDto : UserBaseDto
    {
        [JsonIgnore]
        public Guid UserId { get; set; }

        public IEnumerable<RoleEnum> Roles { get; set; }
    }
}
