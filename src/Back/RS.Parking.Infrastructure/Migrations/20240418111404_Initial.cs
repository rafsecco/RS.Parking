using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RS.Parking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
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
                    nr_percentage = table.Column<double>(type: "double", precision: 3, scale: 2, nullable: false),
                    ds_accord = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false, collation: "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_AccordType", x => x.id_accord);
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
                    ds_vehicle = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false, collation: "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_VehicleType", x => x.id_vehicle);
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
                    cd_accord = table.Column<byte>(type: "TINYINT UNSIGNED", nullable: false, defaultValue: (byte)0),
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
                        principalSchema: "RS.Parking",
                        principalTable: "tb_AccordType",
                        principalColumn: "id_accord");
                    table.ForeignKey(
                        name: "FK_tb_ControlInOut_tb_VehicleType_cd_vehicle",
                        column: x => x.cd_vehicle,
                        principalSchema: "RS.Parking",
                        principalTable: "tb_VehicleType",
                        principalColumn: "id_vehicle");
                })
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateIndex(
                name: "idx_tb_ControleInOut-dt_in_dt_out",
                schema: "RS.Parking",
                table: "tb_ControlInOut",
                columns: new[] { "dt_in", "dt_out" });

            migrationBuilder.CreateIndex(
                name: "IX_tb_ControlInOut_cd_accord",
                schema: "RS.Parking",
                table: "tb_ControlInOut",
                column: "cd_accord");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ControlInOut_cd_vehicle",
                schema: "RS.Parking",
                table: "tb_ControlInOut",
                column: "cd_vehicle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_ControlInOut",
                schema: "RS.Parking");

            migrationBuilder.DropTable(
                name: "tb_AccordType",
                schema: "RS.Parking");

            migrationBuilder.DropTable(
                name: "tb_VehicleType",
                schema: "RS.Parking");
        }
    }
}
