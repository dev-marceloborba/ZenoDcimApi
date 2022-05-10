﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZenoDcimManager.Infra.Contexts;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations.Automation
{
    [DbContext(typeof(AutomationContext))]
    partial class AutomationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

            modelBuilder.Entity("ZenoDcimManager.Domain.AutomationContext.Entities.ModbusTag", b =>
                {
                    b.HasOne("ZenoDcimManager.Domain.AutomationContext.Entities.Plc", null)
                        .WithMany("ModbusTags")
                        .HasForeignKey("PlcId");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.AutomationContext.Entities.Plc", b =>
                {
                    b.Navigation("ModbusTags");
                });
#pragma warning restore 612, 618
        }
    }
}
