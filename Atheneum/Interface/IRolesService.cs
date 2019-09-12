using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Atheneum.Entity.Identity;

namespace Atheneum.Interface
{

    public interface IRolesService
    {
        /// <summary>
        /// Get list of roles 
        /// </summary>
        Task<IEnumerable<Role>> GetRoles();
        /// <summary> 
        /// Add role with name
        /// </summary>
        /// <param name="roleName">Name of new role</param>
        Task<Role> AddRole(string roleName);
        /// <summary> 
        /// Update role
        /// </summary>
        /// <param name="role">Role</param>
        Task<Role> UpdateRole(Role role);
        /// <summary> 
        /// Delete role by Id
        /// </summary>
        /// <param name="roleId">Deleteble role id</param>
        Task DeleteRole(Guid roleId);
    }
}
