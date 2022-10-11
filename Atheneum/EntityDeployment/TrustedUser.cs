using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atheneum.EntityDeployment;

public class TrustedUser
{
    public Guid ServerId { get; set; }
    
    public virtual DeploymentServer Server { get; set; }
    
    public Guid UserId { get; set; }
}

public class TrustedUserConfiguration : IEntityTypeConfiguration<TrustedUser>
{
    public void Configure(EntityTypeBuilder<TrustedUser> builder)
    {
        builder
            .HasKey(t => new { t.ServerId, t.UserId });

        builder
            .HasOne(tu => tu.Server)
            .WithMany(s => s.TrustedUsers)
            .HasForeignKey(sc => sc.ServerId);
    }
}