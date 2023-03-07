using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class RelationBetweenRoomAndRack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rack_Room_RoomId",
                table: "Rack");

            migrationBuilder.AddForeignKey(
                name: "FK_Rack_Room_RoomId",
                table: "Rack",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rack_Room_RoomId",
                table: "Rack");

            migrationBuilder.AddForeignKey(
                name: "FK_Rack_Room_RoomId",
                table: "Rack",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id");
        }
    }
}
