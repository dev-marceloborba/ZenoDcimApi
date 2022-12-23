using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class SiteRelationOnEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SiteId",
                table: "Equipment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_SiteId",
                table: "Equipment",
                column: "SiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Site_SiteId",
                table: "Equipment",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Site_SiteId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_SiteId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "Equipment");
        }
    }
}
