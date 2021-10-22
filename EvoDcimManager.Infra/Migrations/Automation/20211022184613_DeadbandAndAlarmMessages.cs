using Microsoft.EntityFrameworkCore.Migrations;

namespace EvoDcimManager.Infra.Migrations.Automation
{
    public partial class DeadbandAndAlarmMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Deadband",
                table: "ModbusTag",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "MessageOff",
                table: "Alarm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageOn",
                table: "Alarm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Alarm",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deadband",
                table: "ModbusTag");

            migrationBuilder.DropColumn(
                name: "MessageOff",
                table: "Alarm");

            migrationBuilder.DropColumn(
                name: "MessageOn",
                table: "Alarm");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Alarm");
        }
    }
}
