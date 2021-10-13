using EvoDcimManager.Domain.UserContext.Entities;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace EvoDcimManager.Infra.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.Entity<User>().ToTable("user");
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
            modelBuilder.Entity<User>().HasIndex(x => x.Email);

            modelBuilder.Entity<User>().Ignore(x => x.Password);
            modelBuilder.Entity<User>().Ignore(x => x.ConfirmationPassword);
        }

    }
}