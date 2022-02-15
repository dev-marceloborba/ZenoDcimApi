// using Microsoft.EntityFrameworkCore;
// using ZenoDcimManager.Domain.DataCenterContext.Entities;

// namespace ZenoDcimManager.Infra.Contexts
// {
//     public class DataCenterContext : DbContext
//     {
//         public DataCenterContext(DbContextOptions<DataCenterContext> options) : base(options)
//         {

//         }
//         public DbSet<Building> Buildings { get; set; }
//         public DbSet<Floor> Floors { get; set; }
//         public DbSet<Room> Rooms { get; set; }
//         public DbSet<Equipment> Equipments { get; set; }

//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//             modelBuilder.Entity<Building>().ToTable("Building");
//             modelBuilder.Entity<Building>().Property(x => x.Campus).HasColumnType("varchar(28)");
//             modelBuilder.Entity<Building>().Property(x => x.Name).HasColumnType("varchar(20)");

//             modelBuilder.Entity<Floor>().ToTable("Floor");
//             modelBuilder.Entity<Floor>().Property(x => x.Name).HasColumnType("varchar(12)");

//             modelBuilder.Entity<Room>().ToTable("Room");
//             modelBuilder.Entity<Room>().Property(x => x.Name).HasColumnType("varchar(12)");

//             modelBuilder.Entity<Equipment>().ToTable("Equipment");
//             modelBuilder.Entity<Equipment>().Property(x => x.ComponentCode).HasColumnType("varchar(30)");
//             modelBuilder.Entity<Equipment>().Property(x => x.Description).HasColumnType("varchar(100)");
//             modelBuilder.Entity<Equipment>().Property(x => x.Component).HasColumnType("varchar(16)");

//         }
//     }
// }