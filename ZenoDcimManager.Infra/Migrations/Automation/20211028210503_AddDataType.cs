using Microsoft.EntityFrameworkCore.Migrations;

namespace ZenoDcimManager.Infra.Migrations.Automation
{
    public partial class AddDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataType",
                table: "ModbusTag",
                type: "varchar(16)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataType",
                table: "ModbusTag");
        }
    }
}
