﻿// <auto-generated />
using System;
using ZenoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ZenoDcimManager.Infra.Migrations
{
    [DbContext(typeof(ActiveContext))]
    [Migration("20211028185948_ActiveInitialCreate")]
    partial class ActiveInitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ZenoDcimManager.Domain.ActiveContext.Entities.BaseEquipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Manufactor")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Model")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("BaseEquipment");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ActiveContext.Entities.Rack", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Localization")
                        .HasColumnType("varchar(12)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rack");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ActiveContext.Entities.RackEquipment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BaseEquipmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FinalPosition")
                        .HasColumnType("int");

                    b.Property<int>("InitialPosition")
                        .HasColumnType("int");

                    b.Property<int>("RackEquipmentType")
                        .HasColumnType("int");

                    b.Property<Guid?>("RackId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BaseEquipmentId");

                    b.HasIndex("RackId");

                    b.ToTable("RackEquipment");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ActiveContext.Entities.RackEquipment", b =>
                {
                    b.HasOne("ZenoDcimManager.Domain.ActiveContext.Entities.BaseEquipment", "BaseEquipment")
                        .WithMany()
                        .HasForeignKey("BaseEquipmentId");

                    b.HasOne("ZenoDcimManager.Domain.ActiveContext.Entities.Rack", null)
                        .WithMany("RackEquipments")
                        .HasForeignKey("RackId");

                    b.Navigation("BaseEquipment");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.ActiveContext.Entities.Rack", b =>
                {
                    b.Navigation("RackEquipments");
                });
#pragma warning restore 612, 618
        }
    }
}