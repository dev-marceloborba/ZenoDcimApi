using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class ChangesOnRackAndEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "RackEquipment",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RackEquipment",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Function",
                table: "RackEquipment",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Occupation",
                table: "RackEquipment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RackEquipmentOrientation",
                table: "RackEquipment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RackMountType",
                table: "RackEquipment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "RackEquipment",
                type: "varchar(14)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "RackEquipment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "RackEquipment",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Rack",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Rack",
                type: "varchar(14)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Rack",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Rack",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Rack",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Power",
                table: "Rack",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client",
                table: "RackEquipment");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "RackEquipment");

            migrationBuilder.DropColumn(
                name: "Function",
                table: "RackEquipment");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "RackEquipment");

            migrationBuilder.DropColumn(
                name: "RackEquipmentOrientation",
                table: "RackEquipment");

            migrationBuilder.DropColumn(
                name: "RackMountType",
                table: "RackEquipment");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "RackEquipment");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "RackEquipment");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "RackEquipment");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Rack");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Rack");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Rack");

            migrationBuilder.DropColumn(
                name: "Power",
                table: "Rack");

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Rack",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "Rack",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldNullable: true);
        }
    }
}
