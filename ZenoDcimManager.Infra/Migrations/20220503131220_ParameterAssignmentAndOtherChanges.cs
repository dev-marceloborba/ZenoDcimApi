using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class ParameterAssignmentAndOtherChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Building_Site_SiteId",
                table: "Building");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentParameter_EquipmentParameterGroup_EquipmentParameterGroupId",
                table: "EquipmentParameter");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentParameter_EquipmentParameterGroupId",
                table: "EquipmentParameter");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "EquipmentParameter");

            migrationBuilder.RenameColumn(
                name: "EquipmentParameterGroupId",
                table: "EquipmentParameter",
                newName: "ModbusTagId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Site",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Group",
                table: "EquipmentParameterGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "SiteId",
                table: "Building",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Parameter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", nullable: true),
                    Unit = table.Column<string>(type: "varchar(5)", nullable: true),
                    LowLimit = table.Column<int>(type: "int", nullable: false),
                    HighLimit = table.Column<int>(type: "int", nullable: false),
                    Scale = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParameterGroupAssignment",
                columns: table => new
                {
                    EquipmentParameterGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterGroupAssignment", x => new { x.ParameterId, x.EquipmentParameterGroupId });
                    table.ForeignKey(
                        name: "FK_ParameterGroupAssignment_EquipmentParameterGroup_EquipmentParameterGroupId",
                        column: x => x.EquipmentParameterGroupId,
                        principalTable: "EquipmentParameterGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParameterGroupAssignment_Parameter_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "Parameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParameterGroupAssignment_EquipmentParameterGroupId",
                table: "ParameterGroupAssignment",
                column: "EquipmentParameterGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Building_Site_SiteId",
                table: "Building",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Building_Site_SiteId",
                table: "Building");

            migrationBuilder.DropTable(
                name: "ParameterGroupAssignment");

            migrationBuilder.DropTable(
                name: "Parameter");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "EquipmentParameterGroup");

            migrationBuilder.RenameColumn(
                name: "ModbusTagId",
                table: "EquipmentParameter",
                newName: "EquipmentParameterGroupId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Site",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "EquipmentParameter",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SiteId",
                table: "Building",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentParameter_EquipmentParameterGroupId",
                table: "EquipmentParameter",
                column: "EquipmentParameterGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Building_Site_SiteId",
                table: "Building",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentParameter_EquipmentParameterGroup_EquipmentParameterGroupId",
                table: "EquipmentParameter",
                column: "EquipmentParameterGroupId",
                principalTable: "EquipmentParameterGroup",
                principalColumn: "Id");
        }
    }
}
