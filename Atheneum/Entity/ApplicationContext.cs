using Microsoft.EntityFrameworkCore;

namespace Atheneum.Entity.Identity
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<UserInRole> UserInRole { get; set; }
        public DbSet<ChatRoom> ChatRoom { get; set; }
        public DbSet<ChatPrivate> ChatPrivate { get; set; }
        public DbSet<Issue> Issue { get; set; }

        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ProfileConfiguration());
            builder.ApplyConfiguration(new UserInRoleConfiguration());
            builder.ApplyConfiguration(new ChatRoomConfiguration());
            builder.ApplyConfiguration(new ChatPrivateConfiguration());
            builder.ApplyConfiguration(new IssueConfiguration());
        }
    }
}
