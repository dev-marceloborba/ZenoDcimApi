using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class NavigationPropertiesOnActiveContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentParameter_Equipment_EquipmentId",
                table: "EquipmentParameter");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentParameter_EquipmentParameterGroup_EquipmentParameterGroupId",
                table: "EquipmentParameter");

            migrationBuilder.DropForeignKey(
                name: "FK_Floor_Building_BuildingId",
                table: "Floor");

            migrationBuilder.DropForeignKey(
                name: "FK_RackEquipment_Rack_RackId",
                table: "RackEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Floor_FloorId",
                table: "Room");

            migrationBuilder.AlterColumn<Guid>(
                name: "FloorId",
                table: "Room",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RackId",
                table: "RackEquipment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RackId",
                table: "Rack",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RackPduId",
                table: "Rack",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "Rack",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "BuildingId",
                table: "Floor",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EquipmentParameterGroupId",
                table: "EquipmentParameter",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EquipmentId",
                table: "EquipmentParameter",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentParameter_Equipment_EquipmentId",
                table: "EquipmentParameter",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentParameter_EquipmentParameterGroup_EquipmentParameterGroupId",
                table: "EquipmentParameter",
                column: "EquipmentParameterGroupId",
                principalTable: "EquipmentParameterGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Floor_Building_BuildingId",
                table: "Floor",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RackEquipment_Rack_RackId",
                table: "RackEquipment",
                column: "RackId",
                principalTable: "Rack",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Floor_FloorId",
                table: "Room",
                column: "FloorId",
                principalTable: "Floor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentParameter_Equipment_EquipmentId",
                table: "EquipmentParameter");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentParameter_EquipmentParameterGroup_EquipmentParameterGroupId",
                table: "EquipmentParameter");

            migrationBuilder.DropForeignKey(
                name: "FK_Floor_Building_BuildingId",
                table: "Floor");

            migrationBuilder.DropForeignKey(
                name: "FK_RackEquipment_Rack_RackId",
                table: "RackEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Floor_FloorId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "RackId",
                table: "Rack");

            migrationBuilder.DropColumn(
                name: "RackPduId",
                table: "Rack");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Rack");

            migrationBuilder.AlterColumn<Guid>(
                name: "FloorId",
                table: "Room",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "RackId",
                table: "RackEquipment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "BuildingId",
                table: "Floor",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "EquipmentParameterGroupId",
                table: "EquipmentParameter",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "EquipmentId",
                table: "EquipmentParameter",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentParameter_Equipment_EquipmentId",
                table: "EquipmentParameter",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentParameter_EquipmentParameterGroup_EquipmentParameterGroupId",
                table: "EquipmentParameter",
                column: "EquipmentParameterGroupId",
                principalTable: "EquipmentParameterGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Floor_Building_BuildingId",
                table: "Floor",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RackEquipment_Rack_RackId",
                table: "RackEquipment",
                column: "RackId",
                principalTable: "Rack",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Floor_FloorId",
                table: "Room",
                column: "FloorId",
                principalTable: "Floor",
                principalColumn: "Id");
        }
    }
}
