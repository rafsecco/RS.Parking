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
            migrationBuilder.EnsureSchema(
                name: "RS.Parking");

            migrationBuilder.CreateTable(
                name: "tb_AccordType",
                schema: "RS.Parking",
                columns: table => new
                {
                    id_accord = table.Column<byte>(type: "TINYINT UNSIGNED", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    bln_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    dt_dateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()"),
                    ie_accord = table.Column<ushort>(type: "smallint unsigned", nullable: false),
                    nr_percentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    ds_accord = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_AccordType", x => x.id_accord);
                })
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "tb_ControlInOut",
                schema: "RS.Parking",
                columns: table => new
                {
                    id_controlInOut = table.Column<ulong>(type: "BIGINT UNSIGNED", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cd_vehicle = table.Column<byte>(type: "TINYINT UNSIGNED", nullable: false),
                    cd_accord = table.Column<byte>(type: "TINYINT UNSIGNED", nullable: true),
                    dt_in = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()"),
                    dt_out = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ds_licensePlate = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: false, collation: "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ControlInOut", x => x.id_controlInOut);
                })
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "tb_VehicleType",
                schema: "RS.Parking",
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

            migrationBuilder.InsertData(
                schema: "RS.Parking",
                table: "tb_AccordType",
                columns: new[] { "id_accord", "ie_accord", "bln_active", "dt_dateCreated", "ds_accord", "nr_percentage" },
                values: new object[,]
                {
                    { (byte)1, (ushort)0, true, new DateTime(2022, 11, 12, 9, 1, 57, 438, DateTimeKind.Local).AddTicks(9929), "PharmaTech", 0m },
                    { (byte)2, (ushort)1, true, new DateTime(2022, 11, 12, 9, 1, 57, 438, DateTimeKind.Local).AddTicks(9932), "Subway", 50.0m },
                    { (byte)3, (ushort)2, true, new DateTime(2022, 11, 12, 9, 1, 57, 438, DateTimeKind.Local).AddTicks(9935), "McDonald's", 100m }
                });

            migrationBuilder.InsertData(
                schema: "RS.Parking",
                table: "tb_ControlInOut",
                columns: new[] { "id_controlInOut", "cd_accord", "dt_in", "dt_out", "ds_licensePlate", "cd_vehicle" },
                values: new object[,]
                {
                    { 1ul, null, new DateTime(2022, 11, 12, 9, 1, 57, 439, DateTimeKind.Local).AddTicks(2670), null, "BRL-123", (byte)1 },
                    { 2ul, null, new DateTime(2022, 11, 12, 9, 1, 57, 439, DateTimeKind.Local).AddTicks(2673), null, "BRL-456", (byte)2 }
                });

            migrationBuilder.InsertData(
                schema: "RS.Parking",
                table: "tb_VehicleType",
                columns: new[] { "id_vehicle", "bln_active", "vl_cost", "dt_dateCreated", "ds_vehicle" },
                values: new object[,]
                {
                    { (byte)1, true, 5m, new DateTime(2022, 11, 12, 9, 1, 57, 439, DateTimeKind.Local).AddTicks(3809), "Car 1" },
                    { (byte)2, true, 5.5m, new DateTime(2022, 11, 12, 9, 1, 57, 439, DateTimeKind.Local).AddTicks(3811), "Car 2" },
                    { (byte)3, true, 3m, new DateTime(2022, 11, 12, 9, 1, 57, 439, DateTimeKind.Local).AddTicks(3813), "Moto 1" },
                    { (byte)4, true, 3.5m, new DateTime(2022, 11, 12, 9, 1, 57, 439, DateTimeKind.Local).AddTicks(3814), "Moto 2" }
                });

            migrationBuilder.CreateIndex(
                name: "idx_tb_ControleInOut_dt_out",
                schema: "RS.Parking",
                table: "tb_ControlInOut",
                column: "dt_out");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_AccordType",
                schema: "RS.Parking");

            migrationBuilder.DropTable(
                name: "tb_ControlInOut",
                schema: "RS.Parking");

            migrationBuilder.DropTable(
                name: "tb_VehicleType",
                schema: "RS.Parking");
        }
    }
}
