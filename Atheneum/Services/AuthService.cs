using Atheneum.Dto.Auth;
using Atheneum.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Atheneum.Entity;
using Atheneum.Enums;

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
            if (await db.Profiles.AnyAsync(x => x.UserName == dto.UserName))
            {
                throw new ConstraintException("UserName");
            }

            if (!string.IsNullOrWhiteSpace(dto.Email) && await db.Profiles.AnyAsync(x => x.Email == dto.Email))
            {
                throw new ConstraintException("Email");
            }

            if (!string.IsNullOrWhiteSpace(dto.Phone) && await db.Profiles.AnyAsync(x => x.PhoneNumber == dto.Phone))
            {
                throw new ConstraintException("Phone");
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

            if (db.Profiles.Count() == 1)
            {
                var allRoles = Enum.GetValues(typeof(RoleEnum))
                    .Cast<RoleEnum>()
                    .Select(x => new UserInRole
                    {
                        UserId = profile.Id,
                        RoleId = x
                    })
                    .Where(x => x.RoleId != 0)
                    .ToArray();

                await db.UserInRole.AddRangeAsync(allRoles);
                await db.SaveChangesAsync();
            }
        }

        public async Task<UserDto> LogIn(LoginDto dto)
        {
            Profile profile = null;

            if (dto.IsPhone)
            {
                profile = await db.Profiles.Include(x => x.User).SingleOrDefaultAsync(x => x.PhoneNumber == dto.Login);
            }
            else if (dto.IsEmail)
            {
                profile = await db.Profiles.Include(x => x.User).SingleOrDefaultAsync(x => x.Email == dto.Login);
            }
            else
            {
                profile = await db.Profiles.Include(x => x.User).SingleOrDefaultAsync(x => x.UserName == dto.Login);
            }

            if (profile == null || profile.User.PasswordHash !=
                GetHashString($"{profile.User.SecurityStamp}#{dto.Password}"))
                throw new UnauthorizedAccessException();

            var res = new UserDto
            {
                Id = profile.Id,
                UserName = profile.UserName,
                Email = profile.Email,
                Phone = profile.PhoneNumber,
                Roles = await db.UserInRole
                    .Where(x => x.UserId == profile.Id)
                    .Select(x => x.RoleId)
                    .ToArrayAsync()
            };

            return res;
        }

        private string GetHashString(string inputString)
        {
            var sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        private IEnumerable<byte> GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
    }
}