using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class EquipmentCardSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentCardSettings",
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
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentCardSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentCardSettings_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentCardSettings_EquipmentParameter_EquipmentParameter1Id",
                        column: x => x.EquipmentParameter1Id,
                        principalTable: "EquipmentParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EquipmentCardSettings_EquipmentParameter_EquipmentParameter2Id",
                        column: x => x.EquipmentParameter2Id,
                        principalTable: "EquipmentParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EquipmentCardSettings_EquipmentParameter_EquipmentParameter3Id",
                        column: x => x.EquipmentParameter3Id,
                        principalTable: "EquipmentParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentCardSettings_EquipmentId",
                table: "EquipmentCardSettings",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentCardSettings_EquipmentParameter1Id",
                table: "EquipmentCardSettings",
                column: "EquipmentParameter1Id");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentCardSettings_EquipmentParameter2Id",
                table: "EquipmentCardSettings",
                column: "EquipmentParameter2Id");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentCardSettings_EquipmentParameter3Id",
                table: "EquipmentCardSettings",
                column: "EquipmentParameter3Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentCardSettings");
        }
    }
}
