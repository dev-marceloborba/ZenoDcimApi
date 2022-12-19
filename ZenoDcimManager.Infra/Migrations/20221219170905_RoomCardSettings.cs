using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class RoomCardSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomCardSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Parameter1Description = table.Column<string>(type: "varchar(30)", nullable: true),
                    Parameter1Enabled = table.Column<bool>(type: "bit", nullable: true),
                    EquipmentParameter1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Parameter2Description = table.Column<string>(type: "varchar(30)", nullable: true),
                    Parameter2Enabled = table.Column<bool>(type: "bit", nullable: true),
                    EquipmentParameter2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Parameter3Description = table.Column<string>(type: "varchar(30)", nullable: true),
                    Parameter3Enabled = table.Column<bool>(type: "bit", nullable: true),
                    EquipmentParameter3Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomCardSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomCardSettings_EquipmentParameter_EquipmentParameter1Id",
                        column: x => x.EquipmentParameter1Id,
                        principalTable: "EquipmentParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RoomCardSettings_EquipmentParameter_EquipmentParameter2Id",
                        column: x => x.EquipmentParameter2Id,
                        principalTable: "EquipmentParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RoomCardSettings_EquipmentParameter_EquipmentParameter3Id",
                        column: x => x.EquipmentParameter3Id,
                        principalTable: "EquipmentParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RoomCardSettings_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomCardSettings_EquipmentParameter1Id",
                table: "RoomCardSettings",
                column: "EquipmentParameter1Id");

            migrationBuilder.CreateIndex(
                name: "IX_RoomCardSettings_EquipmentParameter2Id",
                table: "RoomCardSettings",
                column: "EquipmentParameter2Id");

            migrationBuilder.CreateIndex(
                name: "IX_RoomCardSettings_EquipmentParameter3Id",
                table: "RoomCardSettings",
                column: "EquipmentParameter3Id");

            migrationBuilder.CreateIndex(
                name: "IX_RoomCardSettings_RoomId",
                table: "RoomCardSettings",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomCardSettings");
        }
    }
}
