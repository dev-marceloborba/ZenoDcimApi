using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class ChangedAlarmTypeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighHighLimit",
                table: "EquipmentParameter");

            migrationBuilder.DropColumn(
                name: "HighLimit",
                table: "EquipmentParameter");

            migrationBuilder.DropColumn(
                name: "LowLimit",
                table: "EquipmentParameter");

            migrationBuilder.DropColumn(
                name: "LowLowLimit",
                table: "EquipmentParameter");

            migrationBuilder.RenameColumn(
                name: "AlarmType",
                table: "AlarmRule",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "AlarmType",
                table: "Alarm",
                newName: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "AlarmRule",
                newName: "AlarmType");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Alarm",
                newName: "AlarmType");

            migrationBuilder.AddColumn<double>(
                name: "HighHighLimit",
                table: "EquipmentParameter",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HighLimit",
                table: "EquipmentParameter",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LowLimit",
                table: "EquipmentParameter",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "LowLowLimit",
                table: "EquipmentParameter",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
