using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvoDcimManager.Infra.Migrations
{
    public partial class ActivesInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseEquipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", nullable: true),
                    Model = table.Column<string>(type: "varchar(30)", nullable: true),
                    Manufactor = table.Column<string>(type: "varchar(30)", nullable: true),
                    SerialNumber = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEquipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rack",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Localization = table.Column<string>(type: "varchar(12)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rack", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RackEquipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseEquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RackId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RackEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RackEquipment_BaseEquipment_BaseEquipmentId",
                        column: x => x.BaseEquipmentId,
                        principalTable: "BaseEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RackEquipment_Rack_RackId",
                        column: x => x.RackId,
                        principalTable: "Rack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RackPosition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InitialPosition = table.Column<int>(type: "int", nullable: false),
                    FinalPosition = table.Column<int>(type: "int", nullable: false),
                    RackId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RackPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RackPosition_Rack_RackId",
                        column: x => x.RackId,
                        principalTable: "Rack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RackPosition_RackEquipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "RackEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Server",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cpu = table.Column<string>(type: "varchar(20)", nullable: true),
                    Memory = table.Column<int>(type: "int", nullable: false),
                    Storage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Server", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Server_RackEquipment_Id",
                        column: x => x.Id,
                        principalTable: "RackEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseEquipment_Name",
                table: "BaseEquipment",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_RackEquipment_BaseEquipmentId",
                table: "RackEquipment",
                column: "BaseEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RackEquipment_RackId",
                table: "RackEquipment",
                column: "RackId");

            migrationBuilder.CreateIndex(
                name: "IX_RackPosition_EquipmentId",
                table: "RackPosition",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RackPosition_RackId",
                table: "RackPosition",
                column: "RackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RackPosition");

            migrationBuilder.DropTable(
                name: "Server");

            migrationBuilder.DropTable(
                name: "RackEquipment");

            migrationBuilder.DropTable(
                name: "BaseEquipment");

            migrationBuilder.DropTable(
                name: "Rack");
        }
    }
}
