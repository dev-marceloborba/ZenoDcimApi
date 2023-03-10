using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class NewFieldsOnWorkOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Responsible",
                table: "WorkOrder",
                newName: "Supervisor");

            migrationBuilder.AddColumn<string>(
                name: "Executor",
                table: "WorkOrder",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Manager",
                table: "WorkOrder",
                type: "varchar(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Executor",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "Manager",
                table: "WorkOrder");

            migrationBuilder.RenameColumn(
                name: "Supervisor",
                table: "WorkOrder",
                newName: "Responsible");
        }
    }
}
