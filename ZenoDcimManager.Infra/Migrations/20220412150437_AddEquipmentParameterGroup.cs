using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class AddEquipmentParameterGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EquipmentParameterGroupId",
                table: "EquipmentParameter",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EquipmentParameterGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentParameterGroup", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentParameter_EquipmentParameterGroupId",
                table: "EquipmentParameter",
                column: "EquipmentParameterGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentParameter_EquipmentParameterGroup_EquipmentParameterGroupId",
                table: "EquipmentParameter",
                column: "EquipmentParameterGroupId",
                principalTable: "EquipmentParameterGroup",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentParameter_EquipmentParameterGroup_EquipmentParameterGroupId",
                table: "EquipmentParameter");

            migrationBuilder.DropTable(
                name: "EquipmentParameterGroup");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentParameter_EquipmentParameterGroupId",
                table: "EquipmentParameter");

            migrationBuilder.DropColumn(
                name: "EquipmentParameterGroupId",
                table: "EquipmentParameter");
        }
    }
}
