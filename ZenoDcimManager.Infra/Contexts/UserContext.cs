using ZenoDcimManager.Domain.UserContext.Entities;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace ZenoDcimManager.Infra.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().Property(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Role);
            modelBuilder.Entity<User>().Property(x => x.Active);
            modelBuilder.Entity<User>().Property(x => x.FirstName)
                .HasColumnType("varchar(80)")
                .HasColumnName("FirstName");
            modelBuilder.Entity<User>().Property(x => x.LastName)
                .HasColumnType("varchar(80)")
                .HasColumnName("LastName");
            modelBuilder.Entity<User>().Property(x => x.Email)
                .HasColumnType("varchar(120)")
                .HasColumnName("Email");
            modelBuilder.Entity<User>().Property(x => x.HashedPassword)
                .HasColumnType("varchar(80)");
            modelBuilder.Entity<User>().HasIndex(x => x.Email);

            modelBuilder.Entity<Company>().ToTable("company");
            modelBuilder.Entity<Company>().Property(x => x.CompanyName)
                .HasColumnType("varchar(80)");
            modelBuilder.Entity<Company>().Property(x => x.TradingName)
                .HasColumnType("varchar(80)");
            modelBuilder.Entity<Company>().Property(x => x.RegistrationNumber)
                .HasColumnType("varchar(14)");


            modelBuilder.Entity<Contract>().ToTable("contract");

        }
    }
}