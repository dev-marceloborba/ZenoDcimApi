using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class ManyToOneWithEpAndAlarms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AlarmRule_EquipmentParameterId",
                table: "AlarmRule");

            migrationBuilder.CreateIndex(
                name: "IX_AlarmRule_EquipmentParameterId",
                table: "AlarmRule",
                column: "EquipmentParameterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AlarmRule_EquipmentParameterId",
                table: "AlarmRule");

            migrationBuilder.CreateIndex(
                name: "IX_AlarmRule_EquipmentParameterId",
                table: "AlarmRule",
                column: "EquipmentParameterId",
                unique: true,
                filter: "[EquipmentParameterId] IS NOT NULL");
        }
    }
}
