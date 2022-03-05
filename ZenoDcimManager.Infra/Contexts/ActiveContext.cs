using ZenoDcimManager.Domain.ActiveContext.Entities;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace ZenoDcimManager.Infra.Contexts
{
    public class ActiveContext : DbContext
    {
        public ActiveContext(DbContextOptions<ActiveContext> options)
            : base(options)
        { }

        public DbSet<Rack> Racks { get; set; }
        public DbSet<RackEquipment> RackEquipments { get; set; }
        public DbSet<BaseEquipment> BaseEquipments { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentParameter> EquipmentParameters { get; set; }

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

            modelBuilder.Entity<Building>().ToTable("Building");
            modelBuilder.Entity<Building>().Property(x => x.Campus).HasColumnType("varchar(28)");
            modelBuilder.Entity<Building>().Property(x => x.Name).HasColumnType("varchar(20)");

            modelBuilder.Entity<Floor>().ToTable("Floor");
            modelBuilder.Entity<Floor>().Property(x => x.Name).HasColumnType("varchar(12)");

            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Room>().Property(x => x.Name).HasColumnType("varchar(12)");

            //equipment
            modelBuilder.Entity<Equipment>().ToTable("Equipment");
            modelBuilder.Entity<Equipment>().Property(x => x.ComponentCode).HasColumnType("varchar(30)");
            modelBuilder.Entity<Equipment>().Property(x => x.Description).HasColumnType("varchar(100)");
            modelBuilder.Entity<Equipment>().Property(x => x.Component).HasColumnType("varchar(64)");

            modelBuilder.Entity<EquipmentParameter>().ToTable("EquipmentParameter");
            modelBuilder.Entity<EquipmentParameter>().Property(x => x.Name).HasColumnType("varchar(50)");
            modelBuilder.Entity<EquipmentParameter>().Property(x => x.Address).HasColumnType("varchar(10)");
            modelBuilder.Entity<EquipmentParameter>().Property(x => x.DataSource).HasColumnType("varchar(20)");
            modelBuilder.Entity<EquipmentParameter>().Property(x => x.Unit).HasColumnType("varchar(5)");
        }
    }
}