using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class UserGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", nullable: true),
                    Description = table.Column<string>(type: "varchar(30)", nullable: true),
                    ActionEditConnections = table.Column<bool>(type: "bit", nullable: false),
                    ActionAckAlarms = table.Column<bool>(type: "bit", nullable: false),
                    RegisterUsers = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDatacenter = table.Column<bool>(type: "bit", nullable: false),
                    RegisterAlarms = table.Column<bool>(type: "bit", nullable: false),
                    RegisterNotifications = table.Column<bool>(type: "bit", nullable: false),
                    RegisterParameters = table.Column<bool>(type: "bit", nullable: false),
                    ViewAlarms = table.Column<bool>(type: "bit", nullable: false),
                    ViewParameters = table.Column<bool>(type: "bit", nullable: false),
                    ViewEquipments = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Group");
        }
    }
}
