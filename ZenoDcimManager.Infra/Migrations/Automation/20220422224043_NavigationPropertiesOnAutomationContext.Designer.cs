﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZenoDcimManager.Infra.Contexts;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations.Automation
{
    [DbContext(typeof(AutomationContext))]
    [Migration("20220422224043_NavigationPropertiesOnAutomationContext")]
    partial class NavigationPropertiesOnAutomationContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageOn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Setpoint")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

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

                    b.Property<string>("DataType")
                        .HasColumnType("varchar(16)");

                    b.Property<double>("Deadband")
                        .HasColumnType("float");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PlcId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Size")
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

                    b.Property<string>("Gateway")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufactor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NetworkMask")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Scan")
                        .HasColumnType("int");

                    b.Property<int>("TcpPort")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Plc", (string)null);
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.AutomationContext.Entities.ModbusTag", b =>
                {
                    b.HasOne("ZenoDcimManager.Domain.AutomationContext.Entities.Plc", null)
                        .WithMany("ModbusTags")
                        .HasForeignKey("PlcId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.AutomationContext.Entities.Plc", b =>
                {
                    b.Navigation("ModbusTags");
                });
#pragma warning restore 612, 618
        }
    }
}
