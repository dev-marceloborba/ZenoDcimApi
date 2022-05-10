using ZenoDcimManager.Domain.AutomationContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace ZenoDcimManager.Infra.Contexts
{
    public class AutomationContext : DbContext
    {
        public AutomationContext(DbContextOptions<AutomationContext> options) : base(options)
        {

        }

        public DbSet<Alarm> Alarms { get; set; }
        public DbSet<ModbusTag> ModbusTags { get; set; }
        public DbSet<Plc> Plcs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            // Plc
            modelBuilder.Entity<Plc>().ToTable("Plc");
            modelBuilder.Entity<Plc>().Property(x => x.Name).HasColumnType("varchar(50)");
            modelBuilder.Entity<Plc>().Property(x => x.Manufactor).HasColumnType("varchar(30)");
            modelBuilder.Entity<Plc>().Property(x => x.Model).HasColumnType("varchar(30)");
            modelBuilder.Entity<Plc>().Property(x => x.IpAddress).HasColumnType("varchar(15)");

            // Modbus Tag
            modelBuilder.Entity<ModbusTag>().ToTable("ModbusTag");
            modelBuilder.Entity<ModbusTag>().Property(x => x.DataType).HasColumnType("varchar(16)");
            modelBuilder.Entity<ModbusTag>().Property(x => x.Name).HasColumnType("varchar(50)");
            modelBuilder.Entity<ModbusTag>().Property(x => x.EquipmentParameterName).HasColumnType("varchar(50)");

            // Alarm
            modelBuilder.Entity<Alarm>().ToTable("Alarm");
            modelBuilder.Entity<Alarm>().Property(x => x.Name).HasColumnType("varchar(50)");
            modelBuilder.Entity<Alarm>().Property(x => x.MessageOn).HasColumnType("varchar(200)");
            modelBuilder.Entity<Alarm>().Property(x => x.MessageOff).HasColumnType("varchar(200)");
            modelBuilder.Entity<Alarm>().Property(x => x.TagName).HasColumnType("varchar(50)");
        }
    }
}