using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class RefactorOnAlarm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlarmPriority",
                table: "Alarm");

            migrationBuilder.DropColumn(
                name: "MessageOff",
                table: "Alarm");

            migrationBuilder.DropColumn(
                name: "MessageOn",
                table: "Alarm");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Alarm");

            migrationBuilder.DropColumn(
                name: "TagName",
                table: "Alarm");

            migrationBuilder.RenameColumn(
                name: "Setpoint",
                table: "Alarm",
                newName: "Value");

            migrationBuilder.AlterColumn<string>(
                name: "Expression",
                table: "Parameter",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AlarmRuleId",
                table: "Alarm",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Alarm_AlarmRuleId",
                table: "Alarm",
                column: "AlarmRuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alarm_AlarmRule_AlarmRuleId",
                table: "Alarm",
                column: "AlarmRuleId",
                principalTable: "AlarmRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alarm_AlarmRule_AlarmRuleId",
                table: "Alarm");

            migrationBuilder.DropIndex(
                name: "IX_Alarm_AlarmRuleId",
                table: "Alarm");

            migrationBuilder.DropColumn(
                name: "AlarmRuleId",
                table: "Alarm");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Alarm",
                newName: "Setpoint");

            migrationBuilder.AlterColumn<string>(
                name: "Expression",
                table: "Parameter",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlarmPriority",
                table: "Alarm",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MessageOff",
                table: "Alarm",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageOn",
                table: "Alarm",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Alarm",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TagName",
                table: "Alarm",
                type: "varchar(50)",
                nullable: true);
        }
    }
}
