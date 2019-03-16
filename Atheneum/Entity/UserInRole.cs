using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Atheneum.Entity.Identity
{
    public class UserInRole
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid RoleId { get; set; }

        public Role Role { get; set; }
    }

    public class UserInRoleConfiguration : IEntityTypeConfiguration<UserInRole>
    {
        public void Configure(EntityTypeBuilder<UserInRole> builder)
        {
            builder
                .HasKey(t => new { t.UserId, t.RoleId });

            builder
                .HasOne(sc => sc.User)
                .WithMany(s => s.UserInRoles)
                .HasForeignKey(sc => sc.UserId);

            builder
                .HasOne(sc => sc.Role)
                .WithMany(c => c.UserInRoles)
                .HasForeignKey(sc => sc.RoleId);
        }
    }
}
