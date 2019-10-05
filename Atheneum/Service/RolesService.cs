using Atheneum.Entity.Identity;
using Atheneum.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atheneum.Services
{
    public class RolesService : IRolesService
    {
        private ApplicationContext db;

        public RolesService(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            var roles = await db.Roles.ToArrayAsync();
            return roles;
        }

        public async Task<Role> AddRole(string roleName)
        {
            Role role = new Role
            {
                Id = new Guid(),
                RoleName = roleName
            };
            await db.Roles.AddAsync(role);
            await db.SaveChangesAsync();
            return role;
        }

        public async Task<Role> UpdateRole(Role role)
        {
            var res = await db.Roles.SingleAsync(r => r.Id == role.Id);
            res.RoleName = role.RoleName;
            await db.SaveChangesAsync();
            return res;
        }

        public async Task DeleteRole(Guid roleId)
        {
            Role role = await db.Roles.FindAsync(roleId);
            db.Roles.Remove(role);
            await db.SaveChangesAsync();
        }
    }
}
