using Atheneum.Dto.Auth;
using Atheneum.Entity;
using Atheneum.Enums;
using Atheneum.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<UserEditDto> Details(Guid id)
        {
            var profile = await db.Profiles.FindAsync(id);

            var userdto = new UserEditDto
            {
                UserName = profile.UserName,
                Email = profile.Email,
                Phone = profile.PhoneNumber,
                Comment = profile.Comment
            };

            return userdto;
        }

        public async Task Edit(UserEditDto userdto)
        {
            var profile = await db.Profiles.SingleAsync(x => x.Id == userdto.Id);

            profile.UserName = userdto.UserName;
            profile.Email = userdto.Email;
            profile.PhoneNumber = userdto.Phone;
            profile.Comment = userdto.Comment;

            await db.SaveChangesAsync();
        }

        public async Task SetAvatar(Guid userId, byte[] img)
        {
            var avatar = await db.Avatar.FindAsync(userId);

            if (avatar == null)
            {
                avatar = new Entity.Avatar();

                avatar.UserId = userId;

                await db.Avatar.AddAsync(avatar);
            }

            avatar.ImgData = img;

            await db.SaveChangesAsync();
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
