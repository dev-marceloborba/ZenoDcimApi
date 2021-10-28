using EvoDcimManager.Domain.ActiveContext.Entities;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace EvoDcimManager.Infra.Contexts
{
    public class ActiveContext : DbContext
    {
        public ActiveContext(DbContextOptions<ActiveContext> options)
            : base(options)
        { }

        public DbSet<Rack> Racks { get; set; }
        public DbSet<RackEquipment> RackEquipments { get; set; }
        public DbSet<BaseEquipment> BaseEquipments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            // rack
            modelBuilder.Entity<Rack>().ToTable("Rack");
            modelBuilder.Entity<Rack>().Property(x => x.Localization).HasColumnType("varchar(12)");

            // base equipment
            modelBuilder.Entity<BaseEquipment>().ToTable("BaseEquipment");
            modelBuilder.Entity<BaseEquipment>().Property(x => x.Name).HasColumnType("varchar(30)");
            modelBuilder.Entity<BaseEquipment>().Property(x => x.Model).HasColumnType("varchar(30)");
            modelBuilder.Entity<BaseEquipment>().Property(x => x.Manufactor).HasColumnType("varchar(30)");
            modelBuilder.Entity<BaseEquipment>().Property(x => x.SerialNumber).HasColumnType("varchar(30)");
            modelBuilder.Entity<BaseEquipment>().HasIndex(x => x.Name);

            // rack equipment
            modelBuilder.Entity<RackEquipment>().ToTable("RackEquipment");
        }
    }
}