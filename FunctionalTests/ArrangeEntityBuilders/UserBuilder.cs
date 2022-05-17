using System;
using System.Collections.Generic;
using System.Linq;
using Atheneum.Entity;
using Atheneum.Enums;

namespace FunctionalTests.ArrangeEntityBuilders;

public class UserBuilder
{
    public static readonly string SuperAdminPassword = "!Qwerty23";
    public static readonly string SuperAdminName = "admin";
    public static readonly string SuperAdminEmail = "admin@test.ru";
    public static readonly string SuperAdminPhone = "+79091112233";
    public static readonly string VladName = "Vlad";
    public static readonly string VladEmail = "vlad@asuemail.ru";
    public static readonly string VladPhone = "+79091113344";
    private Profile _profile;

    public UserBuilder(string name, string email, string phone)
    {
        var id = Guid.NewGuid();
        _profile = new Profile
        {
            Id = id,
            UserName = name,
            Email = email,
            PhoneNumber = phone,
            User = new User
            {
                Id = id,
                SecurityStamp = "90261657-e9f1-4b73-96f8-430c18625150",
                PasswordHash = "92EA49A646E44C805568A15AB386888AC4E1C9A3FD82159DB59A98EAF9895DFD"
            }
        };
    }

    public UserBuilder WithAllRoles()
    {
        var allRoles = Enum.GetValues(typeof(RoleEnum))
            .Cast<RoleEnum>()
            .Select(x => new UserInRole
            {
                UserId = _profile.Id,
                RoleId = x
            })
            .Where(x => x.RoleId != 0)
            .ToArray();

        _profile.User.UserInRoles = allRoles;
        return this;
    }

    public UserBuilder WithRoles(ICollection<RoleEnum> roles)
    {
        foreach (var role in roles)
        {
            _profile.User.UserInRoles.Add(new UserInRole {UserId = _profile.Id, RoleId = role});
        }

        return this;
    }

    public Profile Please()
    {
        return _profile;
    }
}