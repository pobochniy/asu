using Atheneum.Enums;
using System;
using System.Collections.Generic;

namespace Atheneum.Dto.Auth
{
    public class UserDto : UserBaseDto
    {
        public Guid Id { get; set; }

        public IEnumerable<RoleEnum> Roles { get; set; }
    }
}
