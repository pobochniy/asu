using Atheneum.Enums;
using System;
using System.Collections.Generic;

namespace Atheneum.Dto.User
{
    public class UserAndRolesDto
    {
        public Guid UserId { get; set; }
        
        public IEnumerable<RoleEnum> Roles { get; set; }
    }
}
