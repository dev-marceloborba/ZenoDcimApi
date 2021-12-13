﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Infra.Migrations.User
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ZenoDcimManager.Domain.UserContext.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .HasColumnType("varchar(80)");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("varchar(14)");

                    b.Property<string>("TradingName")
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("company");
                });

            modelBuilder.Entity("ZenoDcimManager.Domain.UserContext.Entities.Contract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IntervalEndingNotification")
                        .HasColumnType("int");

                    b.Property<double>("PowerConsumptionDailyLimit")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("contract");
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

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Email");

                    b.ToTable("User");
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

            modelBuilder.Entity("ZenoDcimManager.Domain.UserContext.Entities.Company", b =>
                {
                    b.Navigation("Contracts");
                });
#pragma warning restore 612, 618
        }
    }
}
