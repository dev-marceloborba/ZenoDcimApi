using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class FixRackEquipmentRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RackEquipment_Rack_RackId",
                table: "RackEquipment");

            migrationBuilder.AddForeignKey(
                name: "FK_RackEquipment_Rack_RackId",
                table: "RackEquipment",
                column: "RackId",
                principalTable: "Rack",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RackEquipment_Rack_RackId",
                table: "RackEquipment");

            migrationBuilder.AddForeignKey(
                name: "FK_RackEquipment_Rack_RackId",
                table: "RackEquipment",
                column: "RackId",
                principalTable: "Rack",
                principalColumn: "Id");
        }
    }
}
