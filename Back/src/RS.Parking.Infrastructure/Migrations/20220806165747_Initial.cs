using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RS.Parking.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_AccordType",
                columns: table => new
                {
                    id_accord = table.Column<byte>(type: "TINYINT UNSIGNED", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    bln_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    dt_dateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()"),
                    ie_accord = table.Column<int>(type: "int", nullable: false),
                    nr_percentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    ds_accord = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_AccordType", x => x.id_accord);
                })
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "tb_VehicleType",
                columns: table => new
                {
                    id_vehicle = table.Column<byte>(type: "TINYINT UNSIGNED", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    bln_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    dt_dateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()"),
                    vl_cost = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    ds_vehicle = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_VehicleType", x => x.id_vehicle);
                })
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "tb_ControlInOut",
                columns: table => new
                {
                    id_controlInOut = table.Column<ulong>(type: "BIGINT UNSIGNED", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cd_vehicle = table.Column<byte>(type: "TINYINT UNSIGNED", nullable: false),
                    cd_accord = table.Column<byte>(type: "TINYINT UNSIGNED", nullable: false),
                    dt_in = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()"),
                    dt_out = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ds_licensePlate = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: false, collation: "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ControlInOut", x => x.id_controlInOut);
                    table.ForeignKey(
                        name: "FK_tb_ControlInOut_tb_AccordType_cd_accord",
                        column: x => x.cd_accord,
                        principalTable: "tb_AccordType",
                        principalColumn: "id_accord",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_ControlInOut_tb_VehicleType_cd_vehicle",
                        column: x => x.cd_vehicle,
                        principalTable: "tb_VehicleType",
                        principalColumn: "id_vehicle",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.InsertData(
                table: "tb_AccordType",
                columns: new[] { "id_accord", "ie_accord", "bln_active", "dt_dateCreated", "ds_accord", "nr_percentage" },
                values: new object[,]
                {
                    { (byte)1, 0, true, new DateTime(2022, 8, 6, 13, 57, 46, 932, DateTimeKind.Local).AddTicks(3423), "PharmaTech", 0m },
                    { (byte)2, 1, true, new DateTime(2022, 8, 6, 13, 57, 46, 932, DateTimeKind.Local).AddTicks(3426), "Subway", 50.0m },
                    { (byte)3, 2, true, new DateTime(2022, 8, 6, 13, 57, 46, 932, DateTimeKind.Local).AddTicks(3429), "McDonald's", 100m }
                });

            migrationBuilder.InsertData(
                table: "tb_VehicleType",
                columns: new[] { "id_vehicle", "bln_active", "vl_cost", "dt_dateCreated", "ds_vehicle" },
                values: new object[,]
                {
                    { (byte)2, true, 5m, new DateTime(2022, 8, 6, 13, 57, 46, 932, DateTimeKind.Local).AddTicks(6538), "Car 1" },
                    { (byte)3, true, 5.5m, new DateTime(2022, 8, 6, 13, 57, 46, 932, DateTimeKind.Local).AddTicks(6540), "Car 2" },
                    { (byte)4, true, 3m, new DateTime(2022, 8, 6, 13, 57, 46, 932, DateTimeKind.Local).AddTicks(6542), "Moto 1" },
                    { (byte)5, true, 3.5m, new DateTime(2022, 8, 6, 13, 57, 46, 932, DateTimeKind.Local).AddTicks(6543), "Moto 2" }
                });

            migrationBuilder.CreateIndex(
                name: "idx_tb_ControleInOut_dt_out",
                table: "tb_ControlInOut",
                column: "dt_out");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ControlInOut_cd_accord",
                table: "tb_ControlInOut",
                column: "cd_accord");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ControlInOut_cd_vehicle",
                table: "tb_ControlInOut",
                column: "cd_vehicle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_ControlInOut");

            migrationBuilder.DropTable(
                name: "tb_AccordType");

            migrationBuilder.DropTable(
                name: "tb_VehicleType");
        }
    }
}
