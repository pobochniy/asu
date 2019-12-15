using Atheneum.Dto.Auth;
using Atheneum.Entity.Identity;
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
    }
}
