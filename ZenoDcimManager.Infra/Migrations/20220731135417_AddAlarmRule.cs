using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class AddAlarmRule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlarmRule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Conditional = table.Column<int>(type: "int", nullable: false),
                    Setpoint = table.Column<double>(type: "float", nullable: false),
                    EquipmentParameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmRule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlarmRule_EquipmentParameter_EquipmentParameterId",
                        column: x => x.EquipmentParameterId,
                        principalTable: "EquipmentParameter",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlarmRule_EquipmentParameterId",
                table: "AlarmRule",
                column: "EquipmentParameterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlarmRule");
        }
    }
}
