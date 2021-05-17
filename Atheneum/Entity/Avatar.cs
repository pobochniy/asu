using Atheneum.Entity.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace Atheneum.Entity
{
    public class Avatar
    {
        [Key]
        public Guid UserId { get; set; }

        public byte[] ImgData { get; set; }

        public User User { get; set; }

        public class AvatarConfiguration : IEntityTypeConfiguration<Avatar>
        {
            public void Configure(EntityTypeBuilder<Avatar> builder)
            {
                builder
                    .HasOne(a => a.User)
                    .WithOne(u => u.Avatar)
                    .HasForeignKey<Avatar>(a => a.UserId);

                builder
                    .Property(a => a.ImgData)
                    .HasColumnType("Image");
            }
        }
    }
}

