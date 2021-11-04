﻿// <auto-generated />
using System;
using EvoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EvoDcimManager.Infra.Migrations.Automation
{
    [DbContext(typeof(AutomationContext))]
    [Migration("20211028210503_AddDataType")]
    partial class AddDataType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EvoDcimManager.Domain.AutomationContext.Entities.Alarm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AlarmPriority")
                        .HasColumnType("int");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("MessageOff")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageOn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Setpoint")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Alarm");
                });

            modelBuilder.Entity("EvoDcimManager.Domain.AutomationContext.Entities.ModbusTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Address")
                        .HasColumnType("int");

                    b.Property<string>("DataType")
                        .HasColumnType("varchar(16)");

                    b.Property<double>("Deadband")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PlcId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlcId");

                    b.ToTable("ModbusTag");
                });

            modelBuilder.Entity("EvoDcimManager.Domain.AutomationContext.Entities.Plc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Gateway")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufactor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NetworkMask")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Scan")
                        .HasColumnType("int");

                    b.Property<int>("TcpPort")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Plc");
                });

            modelBuilder.Entity("EvoDcimManager.Domain.AutomationContext.Entities.ModbusTag", b =>
                {
                    b.HasOne("EvoDcimManager.Domain.AutomationContext.Entities.Plc", null)
                        .WithMany("ModbusTags")
                        .HasForeignKey("PlcId");
                });

            modelBuilder.Entity("EvoDcimManager.Domain.AutomationContext.Entities.Plc", b =>
                {
                    b.Navigation("ModbusTags");
                });
#pragma warning restore 612, 618
        }
    }
}
