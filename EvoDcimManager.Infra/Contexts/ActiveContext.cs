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
        public DbSet<RackPosition> RackPositions { get; set; }
        // public DbSet<Switch> Switches { get; set; }
        // public DbSet<Storage> Storages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            // rack
            modelBuilder.Entity<Rack>().ToTable("Rack");
            modelBuilder.Entity<Rack>().Property(x => x.Localization).HasColumnType("varchar(12)");
            modelBuilder.Entity<Rack>()
                .HasMany(x => x.Slots)
                .WithOne();

            modelBuilder.Entity<Rack>()
                .Navigation(b => b.Slots)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
            // .WithOne(x => x.Equipment.Rack);
            ;
            // modelBuilder.Entity<Rack>().Property(x => x.Size);
            // modelBuilder.Entity<Rack>().OwnsMany(
            //     p => p.Slots,
            //     a =>
            //     {
            //         a.Property(x => x.InitialPosition);
            //         a.Property(x => x.FinalPosition);
            //         a.OwnsOne(q => q.Equipment,
            //             b =>
            //             {
            //                 b.OwnsOne(r => r.BaseEquipment, c =>
            //                 {
            //                     c.Property(x => x.Name)
            //                         .HasMaxLength(30)
            //                         .HasColumnType("varchar(30)")
            //                         .HasColumnName("Name");

            //                     c.Property(x => x.Model)
            //                         .HasMaxLength(30)
            //                         .HasColumnType("varchar(30)")
            //                         .HasColumnName("Model");

            //                     c.Property(x => x.Manufactor)
            //                         .HasMaxLength(30)
            //                         .HasColumnType("varchar(30)")
            //                         .HasColumnName("Manufactor");

            //                     c.Property(x => x.SerialNumber)
            //                         .HasMaxLength(30)
            //                         .HasColumnType("varchar(30)")
            //                         .HasColumnName("SerialNumber");
            //                 });

            //                 b.HasOne(r => r.Rack).WithOne();
            //             }
            //         );
            //     }
            // );

            // server
            modelBuilder.Entity<Server>().ToTable("Server");
            modelBuilder.Entity<Server>().Property(x => x.Cpu).HasColumnType("varchar(20)");
            // modelBuilder.Entity<Server>().OwnsOne(
            //     p => p.Cpu,
            //     a =>
            //     {
            //         a.Property(x => x.Name)
            //             .HasMaxLength(30)
            //             .HasColumnType("varchar(30)")
            //             .HasColumnName("Cpu");
            //     }
            // );
            // modelBuilder.Entity<Server>().OwnsOne(
            //     p => p.Memory,
            //     a =>
            //     {
            //         a.Property(x => x.Value)
            //             .HasColumnName("Memory");
            //     }
            // );
            // modelBuilder.Entity<Server>().OwnsOne(
            //     p => p.Storage,
            //     a =>
            //     {
            //         a.Property(x => x.Value)
            //             .HasColumnName("Storage");
            //     }
            // );
            // modelBuilder.Entity<Server>().OwnsOne(
            //     p => p.BaseEquipment,
            //     a =>
            //     {
            //         a.Property(x => x.Name)
            //             .HasMaxLength(30)
            //             .HasColumnType("varchar(30)")
            //             .HasColumnName("Name");

            //         a.Property(x => x.Model)
            //             .HasMaxLength(30)
            //             .HasColumnType("varchar(30)")
            //             .HasColumnName("Model");

            //         a.Property(x => x.Manufactor)
            //             .HasMaxLength(30)
            //             .HasColumnType("varchar(30)")
            //             .HasColumnName("Manufactor");

            //         a.Property(x => x.SerialNumber)
            //             .HasMaxLength(30)
            //             .HasColumnType("varchar(30)")
            //             .HasColumnName("SerialNumber");
            //     }
            // );

            // modelBuilder.Entity<Server>().HasOne(x => x.Rack).WithOne();

            // base equipment
            modelBuilder.Entity<BaseEquipment>().ToTable("BaseEquipment");
            modelBuilder.Entity<BaseEquipment>().Property(x => x.Name).HasColumnType("varchar(30)");
            modelBuilder.Entity<BaseEquipment>().Property(x => x.Model).HasColumnType("varchar(30)");
            modelBuilder.Entity<BaseEquipment>().Property(x => x.Manufactor).HasColumnType("varchar(30)");
            modelBuilder.Entity<BaseEquipment>().Property(x => x.SerialNumber).HasColumnType("varchar(30)");
            modelBuilder.Entity<BaseEquipment>().HasIndex(x => x.Name);

            // rack position
            modelBuilder.Entity<RackPosition>().ToTable("RackPosition");
        }
    }
}