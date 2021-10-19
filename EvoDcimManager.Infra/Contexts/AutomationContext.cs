using EvoDcimManager.Domain.AutomationContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace EvoDcimManager.Infra.Contexts
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
            modelBuilder.Entity<Alarm>().ToTable("Alarm");
            modelBuilder.Entity<ModbusTag>().ToTable("ModbusTag");
            modelBuilder.Entity<Plc>().ToTable("Plc");
        }
    }
}