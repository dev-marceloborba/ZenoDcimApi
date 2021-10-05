using EvoDcimManager.Domain.ActiveContext.Entities;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace EvoDcimManager.Infra.Contexts
{
    public class ActiveContext : DbContext
    {
        public ActiveContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Rack> Racks { get; set; }
        public DbSet<Server> Servers { get; set; }
        // public DbSet<Switch> Switches { get; set; }
        // public DbSet<Storage> Storages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            // rack
            modelBuilder.Entity<Rack>().ToTable("rack");
            modelBuilder.Entity<Rack>().Property(x => x.Localization).HasMaxLength(12).HasColumnType("varchar(12)");
            modelBuilder.Entity<Rack>().Property(x => x.Size);
            modelBuilder.Entity<Rack>().OwnsMany(
                p => p.Slots,
                a =>
                {
                    a.Property(x => x.InitialPosition);
                    a.Property(x => x.FinalPosition);
                    a.OwnsOne(q => q.Equipment,
                        b =>
                        {
                            b.OwnsOne(r => r.BaseEquipment, c =>
                            {
                                c.Property(x => x.Name).HasMaxLength(30).HasColumnType("varchar(30)");
                                c.Property(x => x.Model).HasMaxLength(30).HasColumnType("varchar(30)");
                                c.Property(x => x.Manufactor).HasMaxLength(30).HasColumnType("varchar(30)");
                                c.Property(x => x.SerialNumber).HasMaxLength(30).HasColumnType("varchar(30)");
                            });
                            // b.OwnsOne(r => r.Rack, c =>
                            // {

                            // });
                        }
                    );
                }
            );

            // server
            modelBuilder.Entity<Server>().ToTable("server");
            modelBuilder.Entity<Server>().OwnsOne(
                p => p.Cpu,
                a =>
                {
                    a.Property(x => x.Name).HasMaxLength(30).HasColumnType("varchar(30)");
                }
            );
            modelBuilder.Entity<Server>().OwnsOne(
                p => p.Memory,
                a =>
                {
                    a.Property(x => x.Value);
                }
            );
            modelBuilder.Entity<Server>().OwnsOne(
                p => p.Storage,
                a =>
                {
                    a.Property(x => x.Value);
                }
            );
            modelBuilder.Entity<Server>().OwnsOne(
                p => p.BaseEquipment,
                a =>
                {
                    a.Property(x => x.Name).HasMaxLength(30).HasColumnType("varchar(30)");
                    a.Property(x => x.Model).HasMaxLength(30).HasColumnType("varchar(30)");
                    a.Property(x => x.Manufactor).HasMaxLength(30).HasColumnType("varchar(30)");
                    a.Property(x => x.SerialNumber).HasMaxLength(30).HasColumnType("varchar(30)");
                }
            );


        }
    }
}