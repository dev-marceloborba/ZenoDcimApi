using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class RemovedMapConfigFromModbusTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DataType",
                table: "ModbusTag",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(16)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataType",
                table: "ModbusTag",
                type: "varchar(16)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
