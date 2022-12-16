using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class SiteBuildingCardSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SiteBuildingCardSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Parameter1Description = table.Column<string>(type: "varchar(30)", nullable: true),
                    EquipmentParameter1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Parameter2Description = table.Column<string>(type: "varchar(30)", nullable: true),
                    EquipmentParameter2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Parameter3Description = table.Column<string>(type: "varchar(30)", nullable: true),
                    EquipmentParameter3Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteBuildingCardSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteBuildingCardSettings_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiteBuildingCardSettings_EquipmentParameter_EquipmentParameter1Id",
                        column: x => x.EquipmentParameter1Id,
                        principalTable: "EquipmentParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SiteBuildingCardSettings_EquipmentParameter_EquipmentParameter2Id",
                        column: x => x.EquipmentParameter2Id,
                        principalTable: "EquipmentParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SiteBuildingCardSettings_EquipmentParameter_EquipmentParameter3Id",
                        column: x => x.EquipmentParameter3Id,
                        principalTable: "EquipmentParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SiteBuildingCardSettings_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SiteBuildingCardSettings_BuildingId",
                table: "SiteBuildingCardSettings",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteBuildingCardSettings_EquipmentParameter1Id",
                table: "SiteBuildingCardSettings",
                column: "EquipmentParameter1Id");

            migrationBuilder.CreateIndex(
                name: "IX_SiteBuildingCardSettings_EquipmentParameter2Id",
                table: "SiteBuildingCardSettings",
                column: "EquipmentParameter2Id");

            migrationBuilder.CreateIndex(
                name: "IX_SiteBuildingCardSettings_EquipmentParameter3Id",
                table: "SiteBuildingCardSettings",
                column: "EquipmentParameter3Id");

            migrationBuilder.CreateIndex(
                name: "IX_SiteBuildingCardSettings_SiteId",
                table: "SiteBuildingCardSettings",
                column: "SiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteBuildingCardSettings");
        }
    }
}
