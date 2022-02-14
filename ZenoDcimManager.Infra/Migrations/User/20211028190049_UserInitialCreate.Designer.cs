﻿// <auto-generated />
using System;
using ZenoDcimManager.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ZenoDcimManager.Infra.Migrations.User
{
    [DbContext(typeof(UserContext))]
    [Migration("20211028190049_UserInitialCreate")]
    partial class UserInitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ZenoDcimManager.Domain.UserContext.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

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

                    b.HasIndex("Email");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}