using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class RemovedLimitsOnParameter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighHighLimit",
                table: "Parameter");

            migrationBuilder.DropColumn(
                name: "HighLimit",
                table: "Parameter");

            migrationBuilder.DropColumn(
                name: "LowLimit",
                table: "Parameter");

            migrationBuilder.DropColumn(
                name: "LowLowLimit",
                table: "Parameter");

            migrationBuilder.AddColumn<int>(
                name: "AlarmType",
                table: "AlarmRule",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AlarmType",
                table: "Alarm",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlarmType",
                table: "AlarmRule");

            migrationBuilder.DropColumn(
                name: "AlarmType",
                table: "Alarm");

            migrationBuilder.AddColumn<int>(
                name: "HighHighLimit",
                table: "Parameter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HighLimit",
                table: "Parameter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LowLimit",
                table: "Parameter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LowLowLimit",
                table: "Parameter",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
