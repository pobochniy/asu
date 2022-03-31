using Atheneum.Dto.Auth;
using Atheneum.Entity;
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

        Task<UserEditDto> Details(Guid id);

        Task Edit(UserEditDto userEditDto);

        Task SetAvatar(Guid userId, byte[] img);

        Task SetRoles(Guid userId, IEnumerable<RoleEnum> roles);
    }
}
