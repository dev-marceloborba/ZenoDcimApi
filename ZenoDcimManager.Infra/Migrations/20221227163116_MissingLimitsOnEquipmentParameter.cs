using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class MissingLimitsOnEquipmentParameter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "HighHighLimit",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighHighLimit",
                table: "EquipmentParameter");

            migrationBuilder.DropColumn(
                name: "LowLowLimit",
                table: "EquipmentParameter");
        }
    }
}
