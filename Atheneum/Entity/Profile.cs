using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace Atheneum.Entity;

public class Profile
{
    [Key]
    public Guid Id { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    /// <summary>
    /// Деньги пользователя
    /// </summary>
    public decimal Cash { get; set; }

    public string Comment { get; set; }

    public virtual User User { get; set; }

    public string ToCustomString()
    {
        return $"{this.UserName} {this.Email} {this.PhoneNumber}".Trim();
    }
}

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder
            .HasIndex(u => u.UserName)
            .IsUnique();

        builder
            .HasIndex(u => u.Email)
            .IsUnique();

        builder
            .HasIndex(u => u.PhoneNumber)
            .IsUnique();
        builder
            .HasIndex(u => u.PhoneNumber)
            .IsUnique();

        builder
            .Property(x => x.Cash)
            .HasPrecision(18, 10)
            .HasDefaultValue(0);

        builder
            .Property(u => u.Comment)
            .HasColumnType("nvarchar(4000)");
    }
}