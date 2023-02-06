using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Infra.Contexts.Mappers;
using ZenoDcimManager.Domain.ServiceOrderContext.Entities;

namespace ZenoDcimManager.Infra.Contexts
{
    public class ZenoContext : DbContext
    {
        public ZenoContext(DbContextOptions<ZenoContext> options) : base(options)
        {

        }

        // Usuário
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserPreferencies> UserPreferencies { get; set; }

        // Datacenter
        public DbSet<Rack> Racks { get; set; }
        public DbSet<BaseEquipment> BaseEquiments { get; set; }
        public DbSet<RackEquipment> RackEquipments { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentParameter> EquipmentParameters { get; set; }
        public DbSet<EquipmentParameterGroup> EquipmentParameterGroups { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<VirtualParameter> VirtualParameters { get; set; }
        public DbSet<ParameterGroupAssignment> ParameterGroupAssignments { get; set; }

        // Automação
        public DbSet<Alarm> Alarms { get; set; }
        public DbSet<AlarmRule> AlarmRules { get; set; }
        public DbSet<ModbusTag> ModbusTags { get; set; }
        public DbSet<Plc> Plcs { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<SiteCardSettings> SiteCardSettings { get; set; }
        public DbSet<BuildingCardSettings> BuildingCardSettings { get; set; }
        public DbSet<RoomCardSettings> RoomCardSettings { get; set; }
        public DbSet<EquipmentCardSettings> EquipmentCardSettings { get; set; }

        // Ordem de serviço
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Usuário
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new ContractMap());
            modelBuilder.ApplyConfiguration(new GroupMap());
            modelBuilder.ApplyConfiguration(new UserPreferenciesMap());

            // Datacenter
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
            modelBuilder.ApplyConfiguration(new VirtualParameterMap());
            modelBuilder.ApplyConfiguration(new ParameterGroupAssignmentMap());

            // Automação
            modelBuilder.ApplyConfiguration(new AlarmMap());
            modelBuilder.ApplyConfiguration(new ModbusTagMap());
            modelBuilder.ApplyConfiguration(new PlcMap());
            modelBuilder.ApplyConfiguration(new RealtimeDataMap());
            modelBuilder.ApplyConfiguration(new AlarmRuleMap());
            modelBuilder.ApplyConfiguration(new MeasureMap());
            modelBuilder.ApplyConfiguration(new SiteCardSettingsMap());
            modelBuilder.ApplyConfiguration(new BuildingCardSettingsMap());
            modelBuilder.ApplyConfiguration(new RoomCardSettingsMap());
            modelBuilder.ApplyConfiguration(new EquipmentCardSettingsMap());

            // Ordem de serviço
            modelBuilder.ApplyConfiguration(new WorkOrderMap());
            modelBuilder.ApplyConfiguration(new SupplierMap());
        }
    }
}