using System;
using System.Linq;
using Atheneum.Entity;
using Atheneum.Enums;

namespace FunctionalTests.Arranges;

public class ArrangeUsers
{
    public readonly static string SuperAdminPassword = "!Qwerty23";
    public readonly static Profile SuperAdmin = new Profile
    {
        Id = Guid.Parse("08da1a65-e8fb-4f15-8828-fb672b79b012"),
        UserName = "admin",
        Email = "admin@test.ru",
        PhoneNumber = "+79091112233",
        User = new User
        {
            SecurityStamp = "90261657-e9f1-4b73-96f8-430c18625150",
            PasswordHash = "92EA49A646E44C805568A15AB386888AC4E1C9A3FD82159DB59A98EAF9895DFD"
        }
    };
    
    public void CreateSuperAdmin(ApplicationContext db)
    {
        db.Profiles.Add(SuperAdmin);
        db.SaveChanges();

        var allRoles = Enum.GetValues(typeof(RoleEnum))
            .Cast<RoleEnum>()
            .Select(x => new UserInRole
            {
                UserId = SuperAdmin.Id,
                RoleId = x
            })
            .Where(x => x.RoleId != 0)
            .ToArray();

        db.UserInRole.AddRange(allRoles);
        db.SaveChanges();
    }
}