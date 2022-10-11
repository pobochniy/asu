using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Atheneum.EntityDeployment;

public class DeploymentLog
{
    [Key]
    public Guid Id { get; set; }
    
    public DateTime UtcDate { get; set; }
    
    [MaxLength(100)]
    public Guid UserId { get; set; }
    
    [MaxLength(100)]
    public string UserName { get; set; } 
    
    public Guid ServerId { get; set; }
    
    public DeploymentServer Server { get; set; }
      
    public Guid DockerImageId { get; set; }
    
    public ImagesMetadata DockerImage { get; set; }
}

public class DeploymentLogConfiguration : IEntityTypeConfiguration<DeploymentLog>
{
    public void Configure(EntityTypeBuilder<DeploymentLog> builder)
    {
        builder
            .HasOne(tu => tu.Server)
            .WithMany(s => s.Logs)
            .HasForeignKey(sc => sc.ServerId);
        
        builder
            .HasOne(tu => tu.DockerImage)
            .WithMany(s => s.Logs)
            .HasForeignKey(sc => sc.ServerId);
    }
}