using Atheneum.Dto.Account;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Atheneum.Interface
{
    public interface IAuthService
    {
        Task Register(LoginDto model);

        Task<ClaimsIdentity> LogIn(LoginDto dto);

        Task<IEnumerable<string>> GetRoles(Guid userId);
    }
}
