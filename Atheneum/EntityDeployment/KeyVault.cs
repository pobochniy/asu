using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atheneum.EntityDeployment;

public class KeyVault
{
    public Guid ServerId { get; set; }
    
    public virtual DeploymentServer Server { get; set; }
    
    [MaxLength(100)]
    public string Key { get; set; }
    
    [MaxLength(500)]
    public string Vault { get; set; }
}

public class KeyVaultConfiguration : IEntityTypeConfiguration<KeyVault>
{
    public void Configure(EntityTypeBuilder<KeyVault> builder)
    {
        builder
            .HasKey(t => new { t.ServerId, t.Key });

        builder
            .HasOne(kv => kv.Server)
            .WithMany(s => s.KeyVaults)
            .HasForeignKey(sc => sc.ServerId);
    }
}