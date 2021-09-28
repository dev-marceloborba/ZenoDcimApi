using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.ValueObjects;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            // rack
            modelBuilder.Entity<Rack>().ToTable("rack");
            modelBuilder.Entity<Rack>().Property(x => x.Id);
            modelBuilder.Entity<Rack>().HasKey(x => x.Id);
            modelBuilder.Entity<Rack>().Property(x => x.Size);
            modelBuilder.Entity<Rack>().Property(x => x.OccupedSlots);
            modelBuilder.Entity<Rack>().Property(x => x.Localization).HasColumnType("varchar(12)");
            modelBuilder.Entity<Rack>()
                .HasMany(x => x.Equipments)
                .WithOne(x => x.Rack);
            modelBuilder.Entity<Rack>().HasIndex(x => x.Localization);

            // rack equipment
            modelBuilder.Entity<RackEquipment>().ToTable("rack_equipment");
            modelBuilder.Entity<RackEquipment>().Property(x => x.Id);
            modelBuilder.Entity<RackEquipment>().HasKey(x => x.Id);
            // modelBuilder.Entity<RackEquipment>().Property(x => x.BaseEquipment.Name);

            // server
            modelBuilder.Entity<Server>().ToTable("server");
            // modelBuilder.Entity<Server>().Property(x => x.Id);
            // modelBuilder.Entity<Server>().HasKey(x => x.Id);
            // modelBuilder.Entity<Server>().Property(x => x.BaseEquipment.Name).HasColumnType("varchar(30)");
            // modelBuilder.Entity<Server>().Property(x => x.BaseEquipment.Manufactor).HasColumnType("varchar(40)");
            // modelBuilder.Entity<Server>().Property(x => x.BaseEquipment.Model).HasColumnType("varchar(40)");
            // modelBuilder.Entity<Server>().Property(x => x.BaseEquipment.SerialNumber).HasColumnType("varchar(20)");
            // modelBuilder.Entity<Server>().Property(x => x.Slot.Position);
            // modelBuilder.Entity<Server>().Property(x => x.Slot.Occupation);
            // modelBuilder.Entity<Server>().Property(x => x.Cpu.Name).HasColumnType("varchar(40)");
            // modelBuilder.Entity<Server>().Property(x => x.Memory.Value);
            // modelBuilder.Entity<Server>().Property(x => x.Storage.Value);

        }

    }
}