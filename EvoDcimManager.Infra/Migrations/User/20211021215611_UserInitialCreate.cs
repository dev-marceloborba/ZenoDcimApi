﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvoDcimManager.Infra.Migrations.User
{
    public partial class UserInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(80)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(80)", nullable: true),
                    Email = table.Column<string>(type: "varchar(120)", nullable: true),
                    HashedPassword = table.Column<string>(type: "varchar(80)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_Email",
                table: "user",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
