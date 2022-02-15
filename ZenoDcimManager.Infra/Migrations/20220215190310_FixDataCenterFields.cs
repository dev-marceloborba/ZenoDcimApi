using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class FixDataCenterFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Rack_RackId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_RackPdu_RackPduId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Rooms_RoomId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Floors_Buildings_BuildingId",
                table: "Floors");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Floors_FloorId",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Floors",
                table: "Floors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "Floors",
                newName: "Floor");

            migrationBuilder.RenameTable(
                name: "Equipments",
                newName: "Equipment");

            migrationBuilder.RenameTable(
                name: "Buildings",
                newName: "Building");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_FloorId",
                table: "Room",
                newName: "IX_Room_FloorId");

            migrationBuilder.RenameIndex(
                name: "IX_Floors_BuildingId",
                table: "Floor",
                newName: "IX_Floor_BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipments_RoomId",
                table: "Equipment",
                newName: "IX_Equipment_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipments_RackPduId",
                table: "Equipment",
                newName: "IX_Equipment_RackPduId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipments_RackId",
                table: "Equipment",
                newName: "IX_Equipment_RackId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Room",
                type: "varchar(12)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Floor",
                type: "varchar(12)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Equipment",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComponentCode",
                table: "Equipment",
                type: "varchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Component",
                table: "Equipment",
                type: "varchar(16)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Building",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Campus",
                table: "Building",
                type: "varchar(28)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Floor",
                table: "Floor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipment",
                table: "Equipment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Building",
                table: "Building",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Rack_RackId",
                table: "Equipment",
                column: "RackId",
                principalTable: "Rack",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_RackPdu_RackPduId",
                table: "Equipment",
                column: "RackPduId",
                principalTable: "RackPdu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Room_RoomId",
                table: "Equipment",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Floor_Building_BuildingId",
                table: "Floor",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Floor_FloorId",
                table: "Room",
                column: "FloorId",
                principalTable: "Floor",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Rack_RackId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_RackPdu_RackPduId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Room_RoomId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Floor_Building_BuildingId",
                table: "Floor");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Floor_FloorId",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Floor",
                table: "Floor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipment",
                table: "Equipment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Building",
                table: "Building");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "Floor",
                newName: "Floors");

            migrationBuilder.RenameTable(
                name: "Equipment",
                newName: "Equipments");

            migrationBuilder.RenameTable(
                name: "Building",
                newName: "Buildings");

            migrationBuilder.RenameIndex(
                name: "IX_Room_FloorId",
                table: "Rooms",
                newName: "IX_Rooms_FloorId");

            migrationBuilder.RenameIndex(
                name: "IX_Floor_BuildingId",
                table: "Floors",
                newName: "IX_Floors_BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipment_RoomId",
                table: "Equipments",
                newName: "IX_Equipments_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipment_RackPduId",
                table: "Equipments",
                newName: "IX_Equipments_RackPduId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipment_RackId",
                table: "Equipments",
                newName: "IX_Equipments_RackId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(12)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Floors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(12)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComponentCode",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Component",
                table: "Equipments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(16)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Campus",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(28)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Floors",
                table: "Floors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Rack_RackId",
                table: "Equipments",
                column: "RackId",
                principalTable: "Rack",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_RackPdu_RackPduId",
                table: "Equipments",
                column: "RackPduId",
                principalTable: "RackPdu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Rooms_RoomId",
                table: "Equipments",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Floors_Buildings_BuildingId",
                table: "Floors",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Floors_FloorId",
                table: "Rooms",
                column: "FloorId",
                principalTable: "Floors",
                principalColumn: "Id");
        }
    }
}
