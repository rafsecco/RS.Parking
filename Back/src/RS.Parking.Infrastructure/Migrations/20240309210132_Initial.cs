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
                    cd_accord = table.Column<byte>(type: "TINYINT UNSIGNED", nullable: false),
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
                columns: new[] { "id_accord", "bln_active", "dt_dateCreated", "ds_accord", "ie_accord", "nr_percentage" },
                values: new object[,]
                {
                    { (byte)1, true, new DateTime(2024, 3, 9, 18, 1, 32, 264, DateTimeKind.Local).AddTicks(7562), "No Discount", (ushort)0, 0m },
                    { (byte)2, true, new DateTime(2024, 3, 9, 18, 1, 32, 264, DateTimeKind.Local).AddTicks(7566), "Subway", (ushort)1, 50.0m },
                    { (byte)3, true, new DateTime(2024, 3, 9, 18, 1, 32, 264, DateTimeKind.Local).AddTicks(7569), "McDonald's", (ushort)2, 100m },
                    { (byte)4, true, new DateTime(2024, 3, 9, 18, 1, 32, 264, DateTimeKind.Local).AddTicks(7571), "PharmaTech", (ushort)2, 50m }
                });

            migrationBuilder.InsertData(
                schema: "RS.Parking",
                table: "tb_ControlInOut",
                columns: new[] { "id_controlInOut", "cd_accord", "dt_in", "dt_out", "ds_licensePlate", "cd_vehicle" },
                values: new object[,]
                {
                    { 1ul, (byte)1, new DateTime(2024, 3, 8, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 8, 10, 0, 0, 0, DateTimeKind.Local), "BRL-123", (byte)1 },
                    { 2ul, (byte)2, new DateTime(2024, 3, 8, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 8, 12, 30, 0, 0, DateTimeKind.Local), "BRL-456", (byte)1 },
                    { 3ul, (byte)3, new DateTime(2024, 3, 8, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 8, 14, 30, 0, 0, DateTimeKind.Local), "BRL-789", (byte)1 },
                    { 4ul, (byte)4, new DateTime(2024, 3, 8, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 8, 18, 30, 0, 0, DateTimeKind.Local), "BRL-147", (byte)1 },
                    { 5ul, (byte)1, new DateTime(2024, 3, 7, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 7, 10, 0, 0, 0, DateTimeKind.Local), "BRL-123", (byte)2 },
                    { 6ul, (byte)2, new DateTime(2024, 3, 7, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 7, 12, 30, 0, 0, DateTimeKind.Local), "BRL-456", (byte)2 },
                    { 7ul, (byte)3, new DateTime(2024, 3, 7, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 7, 14, 30, 0, 0, DateTimeKind.Local), "BRL-789", (byte)2 },
                    { 8ul, (byte)4, new DateTime(2024, 3, 7, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 7, 18, 30, 0, 0, DateTimeKind.Local), "BRL-147", (byte)2 },
                    { 9ul, (byte)1, new DateTime(2024, 3, 6, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 6, 10, 0, 0, 0, DateTimeKind.Local), "BRL-123", (byte)3 },
                    { 10ul, (byte)2, new DateTime(2024, 3, 6, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 6, 12, 30, 0, 0, DateTimeKind.Local), "BRL-456", (byte)3 },
                    { 11ul, (byte)3, new DateTime(2024, 3, 6, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 6, 14, 30, 0, 0, DateTimeKind.Local), "BRL-789", (byte)3 },
                    { 12ul, (byte)4, new DateTime(2024, 3, 6, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 6, 18, 30, 0, 0, DateTimeKind.Local), "BRL-147", (byte)3 },
                    { 13ul, (byte)1, new DateTime(2024, 3, 9, 8, 0, 0, 0, DateTimeKind.Local), null, "BRL-123", (byte)3 },
                    { 14ul, (byte)2, new DateTime(2024, 3, 9, 10, 0, 0, 0, DateTimeKind.Local), null, "BRL-456", (byte)3 },
                    { 15ul, (byte)3, new DateTime(2024, 3, 9, 12, 30, 0, 0, DateTimeKind.Local), null, "BRL-789", (byte)3 },
                    { 16ul, (byte)4, new DateTime(2024, 3, 9, 16, 30, 0, 0, DateTimeKind.Local), null, "BRL-147", (byte)3 }
                });

            migrationBuilder.InsertData(
                schema: "RS.Parking",
                table: "tb_VehicleType",
                columns: new[] { "id_vehicle", "bln_active", "vl_cost", "dt_dateCreated", "ds_vehicle" },
                values: new object[,]
                {
                    { (byte)1, true, 4m, new DateTime(2024, 3, 9, 18, 1, 32, 265, DateTimeKind.Local).AddTicks(2993), "Car 1 (small)" },
                    { (byte)2, true, 5.5m, new DateTime(2024, 3, 9, 18, 1, 32, 265, DateTimeKind.Local).AddTicks(2996), "Car 2 (big)" },
                    { (byte)3, true, 3m, new DateTime(2024, 3, 9, 18, 1, 32, 265, DateTimeKind.Local).AddTicks(2998), "Moto 1" }
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
