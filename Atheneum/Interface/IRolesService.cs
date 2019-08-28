using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Atheneum.Entity.Identity;

namespace Atheneum.Interface
{
    public interface IRolesService
    {
        Task<string> Test();
        Task<IEnumerable<Role>> GetRoles();
        Task<IEnumerable<Role>> GetUserRoles(Guid UserId);
        Task AddRole(string roleName);
    }

}
