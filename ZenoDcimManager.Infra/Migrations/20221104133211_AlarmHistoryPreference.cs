using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class AlarmHistoryPreference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserPreferencies_UserPreferenciesId",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "AlarmHistoryTable",
                table: "UserPreferencies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserPreferenciesId",
                table: "User",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserPreferencies_UserPreferenciesId",
                table: "User",
                column: "UserPreferenciesId",
                principalTable: "UserPreferencies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserPreferencies_UserPreferenciesId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AlarmHistoryTable",
                table: "UserPreferencies");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserPreferenciesId",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserPreferencies_UserPreferenciesId",
                table: "User",
                column: "UserPreferenciesId",
                principalTable: "UserPreferencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
