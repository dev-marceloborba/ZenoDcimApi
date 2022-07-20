using ZenoDcimManager.Domain.ActiveContext.Entities;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Infra.Contexts.Mappers;

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
        public DbSet<Site> Sites { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentParameter> EquipmentParameters { get; set; }
        public DbSet<EquipmentParameterGroup> EquipmentParameterGroups { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<ParameterGroupAssignment> ParameterGroupAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfiguration(new RackMap());
            modelBuilder.ApplyConfiguration(new BaseEquipmentMap());
            modelBuilder.ApplyConfiguration(new RackEquipmentMap());
            modelBuilder.ApplyConfiguration(new SiteMap());
            modelBuilder.ApplyConfiguration(new BuildingMap());
            modelBuilder.ApplyConfiguration(new FloorMap());
            modelBuilder.ApplyConfiguration(new RoomMap());
            modelBuilder.ApplyConfiguration(new EquipmentMap());
            modelBuilder.ApplyConfiguration(new EquipmentParameterMap());
            modelBuilder.ApplyConfiguration(new EquipmentParameterGroupMap());
            modelBuilder.ApplyConfiguration(new ParameterMap());
            modelBuilder.ApplyConfiguration(new ParameterGroupAssignmentMap());
        }
    }
}