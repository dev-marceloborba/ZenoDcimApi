using System;
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
                    Name_TempId1 = table.Column<int>(type: "int", nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(120)", nullable: true),
                    Email_TempId1 = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.UniqueConstraint("AK_user_Email_TempId1", x => x.Email_TempId1);
                    table.UniqueConstraint("AK_user_Name_TempId1", x => x.Name_TempId1);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_EmailAddress",
                table: "user",
                column: "EmailAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
