using Atheneum.Entity.Identity;
using Atheneum.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atheneum.Interface
{
    public interface IUsersService
    {
        Task<IEnumerable<Profile>> GetProfiles();

        Task<IEnumerable<RoleEnum>> GetRoles(Guid userId);

        Task SetRoles(Guid userId, IEnumerable<RoleEnum> roles);
    }
}
