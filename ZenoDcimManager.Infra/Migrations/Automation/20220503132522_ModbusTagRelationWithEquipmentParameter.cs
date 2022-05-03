using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations.Automation
{
    public partial class ModbusTagRelationWithEquipmentParameter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gateway",
                table: "Plc");

            migrationBuilder.DropColumn(
                name: "NetworkMask",
                table: "Plc");

            migrationBuilder.DropColumn(
                name: "Scan",
                table: "Plc");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "ModbusTag",
                newName: "Scan");

            migrationBuilder.AddColumn<int>(
                name: "DataSize",
                table: "ModbusTag",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataSize",
                table: "ModbusTag");

            migrationBuilder.RenameColumn(
                name: "Scan",
                table: "ModbusTag",
                newName: "Size");

            migrationBuilder.AddColumn<string>(
                name: "Gateway",
                table: "Plc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NetworkMask",
                table: "Plc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Scan",
                table: "Plc",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
