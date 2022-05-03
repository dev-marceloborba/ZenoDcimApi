﻿using ZenoDcimManager.Domain.ActiveContext.Entities;
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

            // Rack
            modelBuilder.Entity<Rack>().ToTable("Rack");
            modelBuilder.Entity<Rack>().Property(x => x.Localization).HasColumnType("varchar(12)");

            // Base equipment
            modelBuilder.Entity<BaseEquipment>().ToTable("BaseEquipment");
            modelBuilder.Entity<BaseEquipment>().Property(x => x.Name).HasColumnType("varchar(30)");
            modelBuilder.Entity<BaseEquipment>().Property(x => x.Model).HasColumnType("varchar(30)");
            modelBuilder.Entity<BaseEquipment>().Property(x => x.Manufactor).HasColumnType("varchar(30)");
            modelBuilder.Entity<BaseEquipment>().Property(x => x.SerialNumber).HasColumnType("varchar(30)");
            modelBuilder.Entity<BaseEquipment>().HasIndex(x => x.Name);

            // Rack equipment
            modelBuilder.Entity<RackEquipment>().ToTable("RackEquipment");

            // Site
            modelBuilder.Entity<Site>().ToTable("Site");
            modelBuilder.Entity<Site>().Property(x => x.Name).HasColumnType("varchar(20)");

            // Building
            modelBuilder.Entity<Building>().ToTable("Building");
            modelBuilder.Entity<Building>().Property(x => x.Name).HasColumnType("varchar(20)");

            // Floor
            modelBuilder.Entity<Floor>().ToTable("Floor");
            modelBuilder.Entity<Floor>().Property(x => x.Name).HasColumnType("varchar(12)");

            // Room
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Room>().Property(x => x.Name).HasColumnType("varchar(12)");

            // Equipment
            modelBuilder.Entity<Equipment>().ToTable("Equipment");
            modelBuilder.Entity<Equipment>().Property(x => x.ComponentCode).HasColumnType("varchar(30)");
            modelBuilder.Entity<Equipment>().Property(x => x.Description).HasColumnType("varchar(100)");
            modelBuilder.Entity<Equipment>().Property(x => x.Component).HasColumnType("varchar(64)");

            // Equipment parameter
            modelBuilder.Entity<EquipmentParameter>().ToTable("EquipmentParameter");
            modelBuilder.Entity<EquipmentParameter>().Property(x => x.Name).HasColumnType("varchar(50)");
            modelBuilder.Entity<EquipmentParameter>().Property(x => x.DataSource).HasColumnType("varchar(20)");
            modelBuilder.Entity<EquipmentParameter>().Property(x => x.Unit).HasColumnType("varchar(5)");

            // Equipment parameter group
            modelBuilder.Entity<EquipmentParameterGroup>().ToTable("EquipmentParameterGroup");
            modelBuilder.Entity<EquipmentParameterGroup>().Property(x => x.Name).HasColumnType("varchar(30)");

            // Parameters
            modelBuilder.Entity<Parameter>().ToTable("Parameter");
            modelBuilder.Entity<Parameter>().Property(x => x.Name).HasColumnType("varchar(30)");
            modelBuilder.Entity<Parameter>().Property(x => x.Unit).HasColumnType("varchar(5)");

            // Parameter group asignments
            modelBuilder.Entity<ParameterGroupAssignment>().ToTable("ParameterGroupAssignment");
            modelBuilder.Entity<ParameterGroupAssignment>().HasKey(
                x => new { x.ParameterId, x.EquipmentParameterGroupId });
        }
    }
}