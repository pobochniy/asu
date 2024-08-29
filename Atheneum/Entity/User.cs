using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Atheneum.Entity;

public class User
{
    [Key]
    public Guid Id { get; set; }

    public string PasswordHash { get; set; }

    public string SecurityStamp { get; set; }

    public int AccessFailedCount { get; set; }

    public bool EmailConfirmed { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public virtual Profile Profile { get; set; }

    public virtual Avatar Avatar { get; set; }

    public virtual ICollection<UserInRole> UserInRoles { get; set; }

    public virtual ICollection<TimeTracking> TimeTrackings { get; set; }
    public virtual ICollection<HourlyPay> HourlyPays { get; set; }


    public User()
    {
        TimeTrackings = new List<TimeTracking>();
        UserInRoles = new List<UserInRole>();
        HourlyPays = new List<HourlyPay>();
    }
}

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasOne(u => u.Profile)
            .WithOne(p => p.User)
            .HasForeignKey<Profile>(p => p.Id);
    }
}