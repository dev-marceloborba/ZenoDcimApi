using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class RelationConfigOnEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentParameter_Equipment_EquipmentId",
                table: "EquipmentParameter");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentParameter_Equipment_EquipmentId",
                table: "EquipmentParameter",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentParameter_Equipment_EquipmentId",
                table: "EquipmentParameter");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentParameter_Equipment_EquipmentId",
                table: "EquipmentParameter",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id");
        }
    }
}
