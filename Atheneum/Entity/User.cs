using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Atheneum.Entity.Identity
{
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

        public virtual ICollection<UserInRole> UserInRoles { get; set; }

        public User()
        {
            UserInRoles = new List<UserInRole>();
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
}
