using Atheneum.Dto.Auth;
using Atheneum.Entity.Identity;
using Atheneum.Enums;
using Atheneum.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Atheneum.Services
{
    public class UsersService : IUsersService
    {
        private ApplicationContext db;

        public UsersService(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<Profile>> GetProfiles()
        {
            var res = await db.Profiles.ToArrayAsync();

            return res;
        }

        public async Task<IEnumerable<RoleEnum>> GetRoles(Guid userId)
        {
            var query = db.UserInRole
                .Where(x => x.UserId == userId)
                .Select(x => x.RoleId);

            var res = await query.ToArrayAsync();
            return res;
        }

        public async Task SetRoles(Guid userId, IEnumerable<RoleEnum> roles)
        {
            var currentRoles = await db.UserInRole
                .Where(x => x.UserId == userId)
                .ToArrayAsync();

            db.UserInRole.RemoveRange(currentRoles);
            await db.SaveChangesAsync();

            foreach (var role in roles)
            {
                var userInRole = new UserInRole
                {
                    UserId = userId,
                    RoleId = role
                };
                
                db.UserInRole.Add(userInRole);
            }
            await db.SaveChangesAsync();

        }
    }
}
