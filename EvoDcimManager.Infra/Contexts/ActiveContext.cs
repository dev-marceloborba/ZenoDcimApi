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
        public DbSet<Switch> Switches { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<RackEquipment> RackEquipments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            // rack
            modelBuilder.Entity<Rack>().ToTable("Rack");
            modelBuilder.Entity<Rack>().Property(x => x.Localization).HasColumnType("varchar(12)");
            modelBuilder.Entity<Rack>()
                .HasMany(c => c.RackEquipments)
                .WithOne(e => e.Rack);

            // server
            modelBuilder.Entity<Server>().ToTable("Server");
            modelBuilder.Entity<Server>().Property(x => x.Cpu).HasColumnType("varchar(20)");

            // storage
            modelBuilder.Entity<Storage>().ToTable("Storage");

            // switch
            modelBuilder.Entity<Switch>().ToTable("Switch");

            // base equipment
            modelBuilder.Entity<BaseEquipment>().ToTable("BaseEquipment");
            modelBuilder.Entity<BaseEquipment>().Property(x => x.Name).HasColumnType("varchar(30)");
            modelBuilder.Entity<BaseEquipment>().Property(x => x.Model).HasColumnType("varchar(30)");
            modelBuilder.Entity<BaseEquipment>().Property(x => x.Manufactor).HasColumnType("varchar(30)");
            modelBuilder.Entity<BaseEquipment>().Property(x => x.SerialNumber).HasColumnType("varchar(30)");
            modelBuilder.Entity<BaseEquipment>().HasIndex(x => x.Name);

            // rack equipment
            modelBuilder.Entity<RackEquipment>().ToTable("RackEquipment");
            modelBuilder.Entity<RackEquipment>()
                .HasOne(p => p.Rack)
                .WithMany(b => b.RackEquipments)
                .HasForeignKey(p => p.RackId);
            modelBuilder.Entity<RackEquipment>().Ignore(x => x.Rack);
        }
    }
}