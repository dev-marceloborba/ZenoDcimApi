using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class DeleteBehaviourOnCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentCardSettings_Equipment_EquipmentId",
                table: "EquipmentCardSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomCardSettings_Room_RoomId",
                table: "RoomCardSettings");

            migrationBuilder.CreateTable(
                name: "BuildingCardSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Parameter1Description = table.Column<string>(type: "varchar(30)", nullable: true),
                    Parameter1Enabled = table.Column<bool>(type: "bit", nullable: true),
                    EquipmentParameter1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Parameter2Description = table.Column<string>(type: "varchar(30)", nullable: true),
                    Parameter2Enabled = table.Column<bool>(type: "bit", nullable: true),
                    EquipmentParameter2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Parameter3Description = table.Column<string>(type: "varchar(30)", nullable: true),
                    Parameter3Enabled = table.Column<bool>(type: "bit", nullable: true),
                    EquipmentParameter3Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Parameter4Description = table.Column<string>(type: "varchar(30)", nullable: true),
                    Parameter4Enabled = table.Column<bool>(type: "bit", nullable: true),
                    EquipmentParameter4Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Parameter5Description = table.Column<string>(type: "varchar(30)", nullable: true),
                    Parameter5Enabled = table.Column<bool>(type: "bit", nullable: true),
                    EquipmentParameter5Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Parameter6Description = table.Column<string>(type: "varchar(30)", nullable: true),
                    Parameter6Enabled = table.Column<bool>(type: "bit", nullable: true),
                    EquipmentParameter6Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingCardSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingCardSettings_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingCardSettings_EquipmentParameter_EquipmentParameter1Id",
                        column: x => x.EquipmentParameter1Id,
                        principalTable: "EquipmentParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BuildingCardSettings_EquipmentParameter_EquipmentParameter2Id",
                        column: x => x.EquipmentParameter2Id,
                        principalTable: "EquipmentParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BuildingCardSettings_EquipmentParameter_EquipmentParameter3Id",
                        column: x => x.EquipmentParameter3Id,
                        principalTable: "EquipmentParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BuildingCardSettings_EquipmentParameter_EquipmentParameter4Id",
                        column: x => x.EquipmentParameter4Id,
                        principalTable: "EquipmentParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BuildingCardSettings_EquipmentParameter_EquipmentParameter5Id",
                        column: x => x.EquipmentParameter5Id,
                        principalTable: "EquipmentParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BuildingCardSettings_EquipmentParameter_EquipmentParameter6Id",
                        column: x => x.EquipmentParameter6Id,
                        principalTable: "EquipmentParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SiteCardSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Parameter1Description = table.Column<string>(type: "varchar(30)", nullable: true),
                    Parameter1Enabled = table.Column<bool>(type: "bit", nullable: true),
                    EquipmentParameter1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Parameter2Description = table.Column<string>(type: "varchar(30)", nullable: true),
                    Parameter2Enabled = table.Column<bool>(type: "bit", nullable: true),
                    EquipmentParameter2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Parameter3Description = table.Column<string>(type: "varchar(30)", nullable: true),
                    Parameter3Enabled = table.Column<bool>(type: "bit", nullable: true),
                    EquipmentParameter3Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Parameter4Description = table.Column<string>(type: "varchar(30)", nullable: true),
                    Parameter4Enabled = table.Column<bool>(type: "bit", nullable: true),
                    EquipmentParameter4Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Parameter5Description = table.Column<string>(type: "varchar(30)", nullable: true),
                    Parameter5Enabled = table.Column<bool>(type: "bit", nullable: true),
                    EquipmentParameter5Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Parameter6Description = table.Column<string>(type: "varchar(30)", nullable: true),
                    Parameter6Enabled = table.Column<bool>(type: "bit", nullable: true),
                    EquipmentParameter6Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteCardSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteCardSettings_EquipmentParameter_EquipmentParameter1Id",
                        column: x => x.EquipmentParameter1Id,
                        principalTable: "EquipmentParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiteCardSettings_EquipmentParameter_EquipmentParameter2Id",
                        column: x => x.EquipmentParameter2Id,
                        principalTable: "EquipmentParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SiteCardSettings_EquipmentParameter_EquipmentParameter3Id",
                        column: x => x.EquipmentParameter3Id,
                        principalTable: "EquipmentParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SiteCardSettings_EquipmentParameter_EquipmentParameter4Id",
                        column: x => x.EquipmentParameter4Id,
                        principalTable: "EquipmentParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SiteCardSettings_EquipmentParameter_EquipmentParameter5Id",
                        column: x => x.EquipmentParameter5Id,
                        principalTable: "EquipmentParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SiteCardSettings_EquipmentParameter_EquipmentParameter6Id",
                        column: x => x.EquipmentParameter6Id,
                        principalTable: "EquipmentParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SiteCardSettings_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingCardSettings_BuildingId",
                table: "BuildingCardSettings",
                column: "BuildingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuildingCardSettings_EquipmentParameter1Id",
                table: "BuildingCardSettings",
                column: "EquipmentParameter1Id");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingCardSettings_EquipmentParameter2Id",
                table: "BuildingCardSettings",
                column: "EquipmentParameter2Id");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingCardSettings_EquipmentParameter3Id",
                table: "BuildingCardSettings",
                column: "EquipmentParameter3Id");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingCardSettings_EquipmentParameter4Id",
                table: "BuildingCardSettings",
                column: "EquipmentParameter4Id");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingCardSettings_EquipmentParameter5Id",
                table: "BuildingCardSettings",
                column: "EquipmentParameter5Id");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingCardSettings_EquipmentParameter6Id",
                table: "BuildingCardSettings",
                column: "EquipmentParameter6Id");

            migrationBuilder.CreateIndex(
                name: "IX_SiteCardSettings_EquipmentParameter1Id",
                table: "SiteCardSettings",
                column: "EquipmentParameter1Id");

            migrationBuilder.CreateIndex(
                name: "IX_SiteCardSettings_EquipmentParameter2Id",
                table: "SiteCardSettings",
                column: "EquipmentParameter2Id");

            migrationBuilder.CreateIndex(
                name: "IX_SiteCardSettings_EquipmentParameter3Id",
                table: "SiteCardSettings",
                column: "EquipmentParameter3Id");

            migrationBuilder.CreateIndex(
                name: "IX_SiteCardSettings_EquipmentParameter4Id",
                table: "SiteCardSettings",
                column: "EquipmentParameter4Id");

            migrationBuilder.CreateIndex(
                name: "IX_SiteCardSettings_EquipmentParameter5Id",
                table: "SiteCardSettings",
                column: "EquipmentParameter5Id");

            migrationBuilder.CreateIndex(
                name: "IX_SiteCardSettings_EquipmentParameter6Id",
                table: "SiteCardSettings",
                column: "EquipmentParameter6Id");

            migrationBuilder.CreateIndex(
                name: "IX_SiteCardSettings_SiteId",
                table: "SiteCardSettings",
                column: "SiteId",
                unique: true,
                filter: "[SiteId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentCardSettings_Equipment_EquipmentId",
                table: "EquipmentCardSettings",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomCardSettings_Room_RoomId",
                table: "RoomCardSettings",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentCardSettings_Equipment_EquipmentId",
                table: "EquipmentCardSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomCardSettings_Room_RoomId",
                table: "RoomCardSettings");

            migrationBuilder.DropTable(
                name: "BuildingCardSettings");

            migrationBuilder.DropTable(
                name: "SiteCardSettings");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentCardSettings_Equipment_EquipmentId",
                table: "EquipmentCardSettings",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomCardSettings_Room_RoomId",
                table: "RoomCardSettings",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id");
        }
    }
}
