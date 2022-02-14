using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.DataCenterContext.Entities;

namespace ZenoDcimManager.Infra.Contexts
{
    public class DataCenterContext : DbContext
    {
        public DataCenterContext(DbContextOptions options)
        {

        }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Equipment> Equipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>().ToTable("building");
            modelBuilder.Entity<Floor>().ToTable("floor");
            modelBuilder.Entity<Room>().ToTable("room");
            modelBuilder.Entity<Equipment>().ToTable("equipment");
        }
    }
}