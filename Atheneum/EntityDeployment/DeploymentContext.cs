using Microsoft.EntityFrameworkCore;

namespace Atheneum.EntityDeployment
{
    public class DeploymentContext : DbContext
    {
        public DbSet<DeploymentLog> DeploymentLogs { get; set; }
        
        public DbSet<DeploymentServer> Servers { get; set; }
        
        public DbSet<ImagesMetadata> DockerHubImages { get; set; }
        
        public DbSet<KeyVault> KeyVaults { get; set; }
        
        public DbSet<TrustedUser> TrustedUsers { get; set; }

        public DeploymentContext(DbContextOptions<DeploymentContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DeploymentLogConfiguration());
            builder.ApplyConfiguration(new KeyVaultConfiguration());
            builder.ApplyConfiguration(new TrustedUserConfiguration());
        }
    }
}
