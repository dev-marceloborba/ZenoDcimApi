using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvoDcimManager.Infra.Migrations
{
    public partial class ActiveInitialCreate : Migration
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
                    InitialPosition = table.Column<int>(type: "int", nullable: false),
                    FinalPosition = table.Column<int>(type: "int", nullable: false),
                    RackEquipmentType = table.Column<int>(type: "int", nullable: false),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RackEquipment");

            migrationBuilder.DropTable(
                name: "BaseEquipment");

            migrationBuilder.DropTable(
                name: "Rack");
        }
    }
}
