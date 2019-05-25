using Atheneum.Dto.Auth;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atheneum.Interface
{
    public interface IAuthService
    {
        Task Register(RegisterDto model);

        Task<UserDto> LogIn(LoginDto dto);

        Task<IEnumerable<string>> GetRoles(Guid userId);
    }
}
