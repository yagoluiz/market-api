using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Market.Infra.Migrations
{
    public partial class AddStreetFairTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "street_fairs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    census_sector = table.Column<int>(type: "integer", nullable: false),
                    census_grouping = table.Column<int>(type: "integer", nullable: false),
                    district_code = table.Column<int>(type: "integer", nullable: false),
                    district = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    sub_city_hall_code = table.Column<int>(type: "integer", nullable: false),
                    sub_city_hall = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    region5 = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    region8 = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: false),
                    register = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    address = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    address_number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    neighborhood = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    address_details = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    longitude = table.Column<int>(type: "integer", nullable: false),
                    latitude = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_street_fairs", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_street_fairs_district_code",
                table: "street_fairs",
                column: "district_code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "street_fairs");
        }
    }
}
