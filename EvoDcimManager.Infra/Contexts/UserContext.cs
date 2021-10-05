using EvoDcimManager.Domain.UserContext.Entities;
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
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<User>().Property(x => x.Id);
            modelBuilder.Entity<User>().OwnsOne(
                o => o.Name,
                sa =>
                {
                    sa.Property(x => x.FirstName).HasMaxLength(80).HasColumnType("varchar(80)");
                    sa.Property(x => x.LastName).HasMaxLength(80).HasColumnType("varchar(80)");
                }
            );
            modelBuilder.Entity<User>().OwnsOne(
                o => o.Email,
                sa =>
                {
                    sa.Property(x => x.Address).HasMaxLength(120).HasColumnType("varchar(120)");
                    sa.HasIndex(x => x.Address);
                }
            );
            modelBuilder.Entity<User>().Property(x => x.Role);
            modelBuilder.Entity<User>().Property(x => x.Active);
        }

    }
}