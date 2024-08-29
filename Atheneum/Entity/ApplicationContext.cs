using Microsoft.EntityFrameworkCore;

namespace Atheneum.Entity
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Avatar> Avatar { get; set; }
        public DbSet<UserInRole> UserInRole { get; set; }
        public DbSet<ChatRoom> ChatRoom { get; set; }
        public DbSet<ChatPrivate> ChatPrivate { get; set; }
        public DbSet<Issue> Issue { get; set; }
        public DbSet<Epic> Epic { get; set; }
        public DbSet<TimeTracking> TimeTracking { get; set; }
        public DbSet<Sprint> Sprint { get; set; }
        public DbSet<SprintIssues> SprintIssues { get; set; }
        public DbSet<CashFlow> CashFlow { get; set; }
        public DbSet<HourlyPay> HourlyPay { get; set; }
        public DbSet<CrystalProfitPeriod> CrystalProfitPeriods { get; set; }
        public DbSet<CrystalPayment> CrystalPayments { get; set; }

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
            builder.ApplyConfiguration(new TimeTrackingConfiguration());
            builder.ApplyConfiguration(new SprintConfiguration());
            builder.ApplyConfiguration(new CashFlowConfiguration());
            builder.ApplyConfiguration(new HourlyPayConfiguration());
            builder.ApplyConfiguration(new CrystalPaymentConfiguration());
        }
    }
}
