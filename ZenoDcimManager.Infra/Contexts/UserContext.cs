using ZenoDcimManager.Domain.UserContext.Entities;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Infra.Contexts.Mappers;

namespace ZenoDcimManager.Infra.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new ContractMap());

        }
    }
}