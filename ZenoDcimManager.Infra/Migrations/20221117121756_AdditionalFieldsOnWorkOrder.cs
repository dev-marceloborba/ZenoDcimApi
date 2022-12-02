using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class AdditionalFieldsOnWorkOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "WorkOrder",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstimatedRepairTime",
                table: "WorkOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "WorkOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RealRepairTime",
                table: "WorkOrder",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "WorkOrder",
                type: "varchar(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "EstimatedRepairTime",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "RealRepairTime",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "WorkOrder");
        }
    }
}
