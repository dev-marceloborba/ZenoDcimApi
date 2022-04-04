using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class AddDateTrackerOnActiveContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Room",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Room",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "RackPdu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "RackPdu",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "RackEquipment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "RackEquipment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Rack",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Rack",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Floor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Floor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EquipmentParameter",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "EquipmentParameter",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Equipment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Building",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Building",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BaseEquipment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "BaseEquipment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "RackPdu");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "RackPdu");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "RackEquipment");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "RackEquipment");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Rack");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Rack");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Floor");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Floor");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EquipmentParameter");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "EquipmentParameter");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BaseEquipment");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "BaseEquipment");
        }
    }
}
