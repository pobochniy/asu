using Atheneum.Dto.Account;
using Atheneum.Entity.Identity;
using Atheneum.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Atheneum.Services
{
    public class AuthService : IAuthService
    {
        private ApplicationContext db;

        public AuthService(ApplicationContext context)
        {
            db = context;
        }

        public async Task Register(LoginDto dto)
        {
            bool isEntityExists = false;
            var profile = new Profile();

            if (dto.IsPhone)
            {
                isEntityExists = await db.Profiles.AnyAsync(x => x.PhoneNumber == dto.Login);
                profile.PhoneNumber = dto.Login;
            }
            else if (dto.IsEmail)
            {
                isEntityExists = await db.Profiles.AnyAsync(x => x.Email == dto.Login);
                profile.Email = dto.Login;
            }
            else
            {
                isEntityExists = await db.Profiles.AnyAsync(x => x.UserName == dto.Login);
                profile.UserName = dto.Login;
            }

            if (isEntityExists) throw new ArgumentException();

            var id = Guid.NewGuid();
            var salt = Guid.NewGuid();

            var identity = new User
            {
                Id = id,
                SecurityStamp = salt.ToString(),
                PasswordHash = GetHashString($"{salt}#{dto.Password}")
            };

            profile.Id = id;

            using (var transaction = db.Database.BeginTransaction())
            {
                await db.Users.AddAsync(identity);
                await db.Profiles.AddAsync(profile);
                try
                {
                    await db.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }

        public async Task<ClaimsIdentity> LogIn(LoginDto dto)
        {
            Profile profile = null;

            if (dto.IsPhone)
            {
                profile = await db.Profiles.Include(x => x.User).SingleAsync(x => x.PhoneNumber == dto.Login);
            }
            else if (dto.IsEmail)
            {
                profile = await db.Profiles.Include(x => x.User).SingleAsync(x => x.Email == dto.Login);
            }
            else
            {
                profile = await db.Profiles.Include(x => x.User).SingleOrDefaultAsync(x => x.UserName == dto.Login);
            }

            if (profile == null || profile.User.PasswordHash != GetHashString($"{profile.User.SecurityStamp}#{dto.Password}"))
                throw new UnauthorizedAccessException();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, profile.Id.ToString())
            };

            var roles = await db.Roles
                .Where(x => x.UserInRoles.Any(r => r.UserId == profile.Id))
                .Select(x => x.RoleName)
                .ToArrayAsync();

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            return identity;
        }

        private string GetHashString(string inputString)
        {
            var sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        private byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = MD5.Create();  //or use SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public async Task<IEnumerable<string>> GetRoles(Guid userId)
        {
            var roles = await db.Roles
                .Where(x => x.UserInRoles.Any(r => r.UserId == userId))
                .Select(x => x.RoleName)
                .ToArrayAsync();

            return roles;
        }
    }
}
