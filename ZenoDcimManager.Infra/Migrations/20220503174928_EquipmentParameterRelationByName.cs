using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class EquipmentParameterRelationByName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModbusTagId",
                table: "EquipmentParameter");

            migrationBuilder.AddColumn<string>(
                name: "ModbusTagName",
                table: "EquipmentParameter",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModbusTagName",
                table: "EquipmentParameter");

            migrationBuilder.AddColumn<Guid>(
                name: "ModbusTagId",
                table: "EquipmentParameter",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
