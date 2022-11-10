using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class UserPreferencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserPreferenciesId",
                table: "User",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "UserPreferencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserTable = table.Column<int>(type: "int", nullable: false),
                    SiteTable = table.Column<int>(type: "int", nullable: false),
                    BuildingTable = table.Column<int>(type: "int", nullable: false),
                    RoomTable = table.Column<int>(type: "int", nullable: false),
                    ParameterTable = table.Column<int>(type: "int", nullable: false),
                    AvailableParameterTable = table.Column<int>(type: "int", nullable: false),
                    GroupParameterTable = table.Column<int>(type: "int", nullable: false),
                    EquipmentTable = table.Column<int>(type: "int", nullable: false),
                    RuleTable = table.Column<int>(type: "int", nullable: false),
                    EquipmentParameterTable = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPreferencies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_UserPreferenciesId",
                table: "User",
                column: "UserPreferenciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserPreferencies_UserPreferenciesId",
                table: "User",
                column: "UserPreferenciesId",
                principalTable: "UserPreferencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserPreferencies_UserPreferenciesId",
                table: "User");

            migrationBuilder.DropTable(
                name: "UserPreferencies");

            migrationBuilder.DropIndex(
                name: "IX_User_UserPreferenciesId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserPreferenciesId",
                table: "User");
        }
    }
}
