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
    public class AuthService : IAuthService
    {
        private ApplicationContext db;

        public AuthService(ApplicationContext context)
        {
            db = context;
        }

        public async Task Register(RegisterDto dto)
        {

            if (await db.Profiles.AnyAsync(x => x.UserName == dto.UserName)
                || !string.IsNullOrWhiteSpace(dto.Email) && await db.Profiles.AnyAsync(x => x.Email == dto.Email)
                || !string.IsNullOrWhiteSpace(dto.Phone) && await db.Profiles.AnyAsync(x => x.PhoneNumber == dto.Phone))
            {
                throw new ArgumentException();
            }

            var salt = Guid.NewGuid();

            var profile = new Profile
            {
                Id = Guid.NewGuid(),
                UserName = dto.UserName,
                Email = dto.Email,
                PhoneNumber = dto.Phone,
                User = new User
                {
                    SecurityStamp = salt.ToString(),
                    PasswordHash = GetHashString($"{salt}#{dto.Password}")
                }
            };

            await db.Profiles.AddAsync(profile);
            await db.SaveChangesAsync();
        }

        public async Task<UserDto> LogIn(LoginDto dto)
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

            var res = new UserDto
            {
                UserId = profile.Id,
                Login = profile.UserName,
                Email = profile.Email,
                PhoneNumber = profile.PhoneNumber
            };

            res.Roles = await db.Roles
                .Where(x => x.UserInRoles.Any(r => r.UserId == profile.Id))
                .Select(x => x.RoleName)
                .ToArrayAsync();

            return res;
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
