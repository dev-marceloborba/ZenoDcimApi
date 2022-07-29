using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alarm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true),
                    MessageOn = table.Column<string>(type: "varchar(200)", nullable: true),
                    MessageOff = table.Column<string>(type: "varchar(200)", nullable: true),
                    AlarmPriority = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Setpoint = table.Column<double>(type: "float", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    TagName = table.Column<string>(type: "varchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseEquipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", nullable: true),
                    Model = table.Column<string>(type: "varchar(30)", nullable: true),
                    Manufactor = table.Column<string>(type: "varchar(30)", nullable: true),
                    SerialNumber = table.Column<string>(type: "varchar(30)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEquipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "varchar(80)", nullable: true),
                    TradingName = table.Column<string>(type: "varchar(80)", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "varchar(14)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentParameterGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", nullable: true),
                    Group = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentParameterGroup", x => x.Id);
                });

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
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expression = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true),
                    Manufactor = table.Column<string>(type: "varchar(30)", nullable: true),
                    Model = table.Column<string>(type: "varchar(30)", nullable: true),
                    IpAddress = table.Column<string>(type: "varchar(15)", nullable: true),
                    TcpPort = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rack",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Localization = table.Column<string>(type: "varchar(12)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rack", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RackPdu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RackPdu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealtimeData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtimeData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "contract",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PowerConsumptionDailyLimit = table.Column<double>(type: "float", nullable: false),
                    IntervalEndingNotification = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contract_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(80)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(80)", nullable: true),
                    Email = table.Column<string>(type: "varchar(120)", nullable: true),
                    HashedPassword = table.Column<string>(type: "varchar(80)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "ModbusTag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true),
                    Deadband = table.Column<double>(type: "float", nullable: false),
                    Address = table.Column<int>(type: "int", nullable: false),
                    DataSize = table.Column<int>(type: "int", nullable: false),
                    DataType = table.Column<string>(type: "varchar(16)", nullable: true),
                    Scan = table.Column<int>(type: "int", nullable: false),
                    PlcId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EquipmentParameterName = table.Column<string>(type: "varchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModbusTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModbusTag_Plc_PlcId",
                        column: x => x.PlcId,
                        principalTable: "Plc",
                        principalColumn: "Id");
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
                    RackId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RackEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RackEquipment_BaseEquipment_BaseEquipmentId",
                        column: x => x.BaseEquipmentId,
                        principalTable: "BaseEquipment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RackEquipment_Rack_RackId",
                        column: x => x.RackId,
                        principalTable: "Rack",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", nullable: true),
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Building_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Site",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Floor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Floor_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(12)", nullable: true),
                    FloorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Floor_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Component = table.Column<string>(type: "varchar(64)", nullable: true),
                    ComponentCode = table.Column<string>(type: "varchar(30)", nullable: true),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true),
                    Group = table.Column<int>(type: "int", nullable: false),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FloorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RackId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RackPduId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "varchar(14)", nullable: true),
                    PowerLimit = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipment_Floor_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipment_Rack_RackId",
                        column: x => x.RackId,
                        principalTable: "Rack",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipment_RackPdu_RackPduId",
                        column: x => x.RackPduId,
                        principalTable: "RackPdu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipment_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EquipmentParameter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true),
                    Unit = table.Column<string>(type: "varchar(5)", nullable: true),
                    LowLimit = table.Column<double>(type: "float", nullable: false),
                    HighLimit = table.Column<double>(type: "float", nullable: false),
                    Scale = table.Column<int>(type: "int", nullable: false),
                    DataSource = table.Column<string>(type: "varchar(20)", nullable: true),
                    EquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModbusTagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentParameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentParameter_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentParameter_RealtimeData_DataId",
                        column: x => x.DataId,
                        principalTable: "RealtimeData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseEquipment_Name",
                table: "BaseEquipment",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Building_SiteId",
                table: "Building",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_contract_CompanyId",
                table: "contract",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_BuildingId",
                table: "Equipment",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_FloorId",
                table: "Equipment",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_RackId",
                table: "Equipment",
                column: "RackId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_RackPduId",
                table: "Equipment",
                column: "RackPduId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_RoomId",
                table: "Equipment",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentParameter_DataId",
                table: "EquipmentParameter",
                column: "DataId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentParameter_EquipmentId",
                table: "EquipmentParameter",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Floor_BuildingId",
                table: "Floor",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_ModbusTag_PlcId",
                table: "ModbusTag",
                column: "PlcId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterGroupAssignment_EquipmentParameterGroupId",
                table: "ParameterGroupAssignment",
                column: "EquipmentParameterGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RackEquipment_BaseEquipmentId",
                table: "RackEquipment",
                column: "BaseEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RackEquipment_RackId",
                table: "RackEquipment",
                column: "RackId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_FloorId",
                table: "Room",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyId",
                table: "User",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alarm");

            migrationBuilder.DropTable(
                name: "contract");

            migrationBuilder.DropTable(
                name: "EquipmentParameter");

            migrationBuilder.DropTable(
                name: "ModbusTag");

            migrationBuilder.DropTable(
                name: "ParameterGroupAssignment");

            migrationBuilder.DropTable(
                name: "RackEquipment");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "RealtimeData");

            migrationBuilder.DropTable(
                name: "Plc");

            migrationBuilder.DropTable(
                name: "EquipmentParameterGroup");

            migrationBuilder.DropTable(
                name: "Parameter");

            migrationBuilder.DropTable(
                name: "BaseEquipment");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "Rack");

            migrationBuilder.DropTable(
                name: "RackPdu");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Floor");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Site");
        }
    }
}
