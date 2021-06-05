using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace PassengersMonitoring.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "passengersmonitoring");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", ",,")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "route",
                schema: "passengersmonitoring",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    route_number = table.Column<int>(nullable: false),
                    order_number = table.Column<int>(nullable: false),
                    location = table.Column<Point>(type: "geometry (point)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_route", x => x.id);
                    table.UniqueConstraint("ak_route_route_number", x => x.route_number);
                });

            migrationBuilder.CreateTable(
                name: "vehicle",
                schema: "passengersmonitoring",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    vehicle_model = table.Column<int>(maxLength: 500, nullable: false),
                    sits_number = table.Column<int>(maxLength: 1000, nullable: false),
                    route_number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicle", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicle_route_route_number",
                        column: x => x.route_number,
                        principalSchema: "passengersmonitoring",
                        principalTable: "route",
                        principalColumn: "route_number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stop",
                schema: "passengersmonitoring",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    vehicle_id = table.Column<Guid>(nullable: false),
                    passengers_number = table.Column<int>(nullable: false),
                    timestamp = table.Column<DateTime>(nullable: false),
                    location = table.Column<Point>(type: "geometry (point)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stop", x => x.id);
                    table.ForeignKey(
                        name: "fk_stop_vehicle_vehicle_id",
                        column: x => x.vehicle_id,
                        principalSchema: "passengersmonitoring",
                        principalTable: "vehicle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_route_id",
                schema: "passengersmonitoring",
                table: "route",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_route_route_number",
                schema: "passengersmonitoring",
                table: "route",
                column: "route_number");

            migrationBuilder.CreateIndex(
                name: "ix_stop_id",
                schema: "passengersmonitoring",
                table: "stop",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_stop_vehicle_id",
                schema: "passengersmonitoring",
                table: "stop",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_id",
                schema: "passengersmonitoring",
                table: "vehicle",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_route_number",
                schema: "passengersmonitoring",
                table: "vehicle",
                column: "route_number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stop",
                schema: "passengersmonitoring");

            migrationBuilder.DropTable(
                name: "vehicle",
                schema: "passengersmonitoring");

            migrationBuilder.DropTable(
                name: "route",
                schema: "passengersmonitoring");
        }
    }
}
