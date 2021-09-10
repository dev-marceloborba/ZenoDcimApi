using EvoDcimManager.Domain.UserContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace EvoDcimManager.Infra.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<User>().Property(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Name.FirstName).HasMaxLength(80).HasColumnType("varchar(80)");
            modelBuilder.Entity<User>().Property(x => x.Name.LastName).HasMaxLength(80).HasColumnType("varchar(80)");
            modelBuilder.Entity<User>().Property(x => x.Email.Address).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<User>().Property(x => x.Role);
            modelBuilder.Entity<User>().Property(x => x.Active);
            modelBuilder.Entity<User>().HasIndex(x => x.Email);
        }

    }
}