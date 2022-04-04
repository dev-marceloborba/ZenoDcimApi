using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations.Automation
{
    public partial class AddDateTrackerOnAutomationContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Plc",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Plc",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ModbusTag",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ModbusTag",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Alarm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Alarm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Plc");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Plc");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ModbusTag");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ModbusTag");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Alarm");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Alarm");
        }
    }
}
