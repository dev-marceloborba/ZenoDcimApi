using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class NewFieldsOnEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ComponentCode",
                table: "Equipment",
                newName: "SerialNumber");

            migrationBuilder.RenameColumn(
                name: "Component",
                table: "Equipment",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Manufactor",
                table: "Equipment",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Equipment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Manufactor",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Equipment");

            migrationBuilder.RenameColumn(
                name: "SerialNumber",
                table: "Equipment",
                newName: "ComponentCode");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Equipment",
                newName: "Component");
        }
    }
}
