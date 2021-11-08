using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZenoDcimManager.Infra.Migrations.Automation
{
    public partial class AutomationInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alarm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageOn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageOff = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlarmPriority = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Setpoint = table.Column<double>(type: "float", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufactor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NetworkMask = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gateway = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TcpPort = table.Column<int>(type: "int", nullable: false),
                    Scan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModbusTag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    PlcId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deadband = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModbusTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModbusTag_Plc_PlcId",
                        column: x => x.PlcId,
                        principalTable: "Plc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModbusTag_PlcId",
                table: "ModbusTag",
                column: "PlcId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alarm");

            migrationBuilder.DropTable(
                name: "ModbusTag");

            migrationBuilder.DropTable(
                name: "Plc");
        }
    }
}
