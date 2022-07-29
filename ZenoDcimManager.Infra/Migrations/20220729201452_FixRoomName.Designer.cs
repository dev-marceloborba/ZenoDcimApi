﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZenoDcimManager.Infra.Contexts;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    [DbContext(typeof(ZenoContext))]
    [Migration("20220729201452_FixRoomName")]
    partial class FixRoomName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ZenoDcimManager.Domain.ActiveContext.Entities.RealtimeData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RealtimeData", (string)null);
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.AutomationContext.Entities.Alarm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AlarmPriority")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("MessageOff")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("MessageOn")
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)");

                    b.Property<double>("Setpoint")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TagName")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Alarm", (string)null);
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.AutomationContext.Entities.ModbusTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Address")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DataSize")
                        .HasColumnType("int");

                    b.Property<string>("DataType")
                        .HasColumnType("varchar(16)");

                    b.Property<double>("Deadband")
                        .HasColumnType("float");

                    b.Property<string>("EquipmentParameterName")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("PlcId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Scan")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlcId");

                    b.ToTable("ModbusTag", (string)null);
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.AutomationContext.Entities.Plc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IpAddress")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Manufactor")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Model")
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("TcpPort")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Plc", (string)null);
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.UserContext.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .HasColumnType("varchar(80)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("varchar(14)");

                    b.Property<string>("TradingName")
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("company", (string)null);
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.UserContext.Entities.Contract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IntervalEndingNotification")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("PowerConsumptionDailyLimit")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("contract", (string)null);
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.UserContext.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(120)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(80)")
                        .HasColumnName("FirstName");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("varchar(80)");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(80)")
                        .HasColumnName("LastName");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Email");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.BaseEquipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Manufactor")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Model")
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("BaseEquipment", (string)null);
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.Building", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(20)");

                    b.Property<Guid?>("SiteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("Building", (string)null);
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.Equipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BuildingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Component")
                        .HasColumnType("varchar(64)");

                    b.Property<string>("ComponentCode")
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("FloorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Group")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PowerLimit")
                        .HasColumnType("int");

                    b.Property<Guid?>("RackId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RackPduId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Size")
                        .HasColumnType("varchar(14)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("FloorId");

                    b.HasIndex("RackId");

                    b.HasIndex("RackPduId");

                    b.HasIndex("RoomId");

                    b.ToTable("Equipment", (string)null);
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.EquipmentParameter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DataId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DataSource")
                        .HasColumnType("varchar(20)");

                    b.Property<Guid?>("EquipmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("HighLimit")
                        .HasColumnType("float");

                    b.Property<double>("LowLimit")
                        .HasColumnType("float");

                    b.Property<string>("ModbusTagName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Scale")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .HasColumnType("varchar(5)");

                    b.HasKey("Id");

                    b.HasIndex("DataId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("EquipmentParameter", (string)null);
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.EquipmentParameterGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Group")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("EquipmentParameterGroup", (string)null);
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.Floor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BuildingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Floor", (string)null);
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.Parameter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HighLimit")
                        .HasColumnType("int");

                    b.Property<int>("LowLimit")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(30)");

                    b.Property<int>("Scale")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .HasColumnType("varchar(5)");

                    b.HasKey("Id");

                    b.ToTable("Parameter", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Parameter");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.ParameterGroupAssignment", b =>
                {
                    b.Property<Guid>("ParameterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EquipmentParameterGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ParameterId", "EquipmentParameterGroupId");

                    b.HasIndex("EquipmentParameterGroupId");

                    b.ToTable("ParameterGroupAssignment", (string)null);
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.Rack", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Localization")
                        .HasColumnType("varchar(12)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rack", (string)null);
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.RackEquipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BaseEquipmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FinalPosition")
                        .HasColumnType("int");

                    b.Property<int>("InitialPosition")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RackEquipmentType")
                        .HasColumnType("int");

                    b.Property<Guid?>("RackId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BaseEquipmentId");

                    b.HasIndex("RackId");

                    b.ToTable("RackEquipment", (string)null);
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.RackPdu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RackPdu");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("FloorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("FloorId");

                    b.ToTable("Room", (string)null);
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.Site", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Site", (string)null);
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.AutomationContext.Entities.VirtualParameter", b =>
                {
                    b.HasBaseType("ZenoDcimManager.Domain.ZenoContext.Entities.Parameter");

                    b.Property<string>("Expression")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("VirtualParameter");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.AutomationContext.Entities.ModbusTag", b =>
                {
                    b.HasOne("ZenoDcimManager.Domain.AutomationContext.Entities.Plc", null)
                        .WithMany("ModbusTags")
                        .HasForeignKey("PlcId");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.UserContext.Entities.Contract", b =>
                {
                    b.HasOne("ZenoDcimManager.Domain.UserContext.Entities.Company", null)
                        .WithMany("Contracts")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.UserContext.Entities.User", b =>
                {
                    b.HasOne("ZenoDcimManager.Domain.UserContext.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.Building", b =>
                {
                    b.HasOne("ZenoDcimManager.Domain.ZenoContext.Entities.Site", "Site")
                        .WithMany("Buildings")
                        .HasForeignKey("SiteId");

                    b.Navigation("Site");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.Equipment", b =>
                {
                    b.HasOne("ZenoDcimManager.Domain.ZenoContext.Entities.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId");

                    b.HasOne("ZenoDcimManager.Domain.ZenoContext.Entities.Floor", "Floor")
                        .WithMany()
                        .HasForeignKey("FloorId");

                    b.HasOne("ZenoDcimManager.Domain.ZenoContext.Entities.Rack", "Rack")
                        .WithMany()
                        .HasForeignKey("RackId");

                    b.HasOne("ZenoDcimManager.Domain.ZenoContext.Entities.RackPdu", "RackPdu")
                        .WithMany()
                        .HasForeignKey("RackPduId");

                    b.HasOne("ZenoDcimManager.Domain.ZenoContext.Entities.Room", "Room")
                        .WithMany("Equipments")
                        .HasForeignKey("RoomId");

                    b.Navigation("Building");

                    b.Navigation("Floor");

                    b.Navigation("Rack");

                    b.Navigation("RackPdu");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.EquipmentParameter", b =>
                {
                    b.HasOne("ZenoDcimManager.Domain.ActiveContext.Entities.RealtimeData", "Data")
                        .WithMany()
                        .HasForeignKey("DataId");

                    b.HasOne("ZenoDcimManager.Domain.ZenoContext.Entities.Equipment", null)
                        .WithMany("EquipmentParameters")
                        .HasForeignKey("EquipmentId");

                    b.Navigation("Data");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.Floor", b =>
                {
                    b.HasOne("ZenoDcimManager.Domain.ZenoContext.Entities.Building", "Building")
                        .WithMany("Floors")
                        .HasForeignKey("BuildingId");

                    b.Navigation("Building");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.ParameterGroupAssignment", b =>
                {
                    b.HasOne("ZenoDcimManager.Domain.ZenoContext.Entities.EquipmentParameterGroup", "EquipmentParameterGroup")
                        .WithMany("ParameterGroupAssignments")
                        .HasForeignKey("EquipmentParameterGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZenoDcimManager.Domain.ZenoContext.Entities.Parameter", "Parameter")
                        .WithMany("ParameterGroupAssignments")
                        .HasForeignKey("ParameterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquipmentParameterGroup");

                    b.Navigation("Parameter");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.RackEquipment", b =>
                {
                    b.HasOne("ZenoDcimManager.Domain.ZenoContext.Entities.BaseEquipment", "BaseEquipment")
                        .WithMany()
                        .HasForeignKey("BaseEquipmentId");

                    b.HasOne("ZenoDcimManager.Domain.ZenoContext.Entities.Rack", null)
                        .WithMany("RackEquipments")
                        .HasForeignKey("RackId");

                    b.Navigation("BaseEquipment");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.Room", b =>
                {
                    b.HasOne("ZenoDcimManager.Domain.ZenoContext.Entities.Floor", "Floor")
                        .WithMany("Rooms")
                        .HasForeignKey("FloorId");

                    b.Navigation("Floor");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.AutomationContext.Entities.Plc", b =>
                {
                    b.Navigation("ModbusTags");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.UserContext.Entities.Company", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.Building", b =>
                {
                    b.Navigation("Floors");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.Equipment", b =>
                {
                    b.Navigation("EquipmentParameters");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.EquipmentParameterGroup", b =>
                {
                    b.Navigation("ParameterGroupAssignments");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.Floor", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.Parameter", b =>
                {
                    b.Navigation("ParameterGroupAssignments");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.Rack", b =>
                {
                    b.Navigation("RackEquipments");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.Room", b =>
                {
                    b.Navigation("Equipments");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ZenoContext.Entities.Site", b =>
                {
                    b.Navigation("Buildings");
                });
#pragma warning restore 612, 618
        }
    }
}
