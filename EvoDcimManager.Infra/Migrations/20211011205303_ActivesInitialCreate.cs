using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvoDcimManager.Infra.Migrations
{
    public partial class ActivesInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rack",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Localization = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rack", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RackPosition",
                columns: table => new
                {
                    RackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Model = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Manufactor = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    SerialNumber = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Equipment_RackId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Equipment_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InitialPosition = table.Column<int>(type: "int", nullable: false),
                    FinalPosition = table.Column<int>(type: "int", nullable: false),
                    TempId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RackPosition", x => new { x.RackId, x.Id });
                    table.UniqueConstraint("AK_RackPosition_TempId", x => x.TempId);
                    table.ForeignKey(
                        name: "FK_RackPosition_rack_Equipment_RackId",
                        column: x => x.Equipment_RackId,
                        principalTable: "rack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RackPosition_rack_RackId",
                        column: x => x.RackId,
                        principalTable: "rack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "server",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cpu = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Cpu_TempId1 = table.Column<int>(type: "int", nullable: true),
                    Memory = table.Column<int>(type: "int", nullable: true),
                    Memory_TempId1 = table.Column<int>(type: "int", nullable: true),
                    Storage = table.Column<int>(type: "int", nullable: true),
                    Storage_TempId1 = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Model = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Manufactor = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    SerialNumber = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    RackId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_server", x => x.Id);
                    table.UniqueConstraint("AK_server_Cpu_TempId1", x => x.Cpu_TempId1);
                    table.UniqueConstraint("AK_server_Memory_TempId1", x => x.Memory_TempId1);
                    table.UniqueConstraint("AK_server_Storage_TempId1", x => x.Storage_TempId1);
                    table.ForeignKey(
                        name: "FK_server_rack_RackId",
                        column: x => x.RackId,
                        principalTable: "rack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RackPosition_Equipment_RackId",
                table: "RackPosition",
                column: "Equipment_RackId",
                unique: true,
                filter: "[Equipment_RackId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_server_RackId",
                table: "server",
                column: "RackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RackPosition");

            migrationBuilder.DropTable(
                name: "server");

            migrationBuilder.DropTable(
                name: "rack");
        }
    }
}
