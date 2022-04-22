using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations.Automation
{
    public partial class NullableNavigationPropertiesOnAutomationContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModbusTag_Plc_PlcId",
                table: "ModbusTag");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlcId",
                table: "ModbusTag",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ModbusTag_Plc_PlcId",
                table: "ModbusTag",
                column: "PlcId",
                principalTable: "Plc",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModbusTag_Plc_PlcId",
                table: "ModbusTag");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlcId",
                table: "ModbusTag",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ModbusTag_Plc_PlcId",
                table: "ModbusTag",
                column: "PlcId",
                principalTable: "Plc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
