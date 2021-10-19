using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvoDcimManager.Infra.Migrations
{
    public partial class AddOtherEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storage_RackEquipment_Id",
                        column: x => x.Id,
                        principalTable: "RackEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Switch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EthPorts = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Switch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Switch_RackEquipment_Id",
                        column: x => x.Id,
                        principalTable: "RackEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropTable(
                name: "Switch");
        }
    }
}
