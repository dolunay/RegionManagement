using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperAbp.RegionManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SuperAbpCities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperAbpCities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuperAbpDistricts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperAbpDistricts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuperAbpProvinces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperAbpProvinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuperAbpRegionLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperAbpRegionLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuperAbpStreets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperAbpStreets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuperAbpVillages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StreetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperAbpVillages", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuperAbpCities");

            migrationBuilder.DropTable(
                name: "SuperAbpDistricts");

            migrationBuilder.DropTable(
                name: "SuperAbpProvinces");

            migrationBuilder.DropTable(
                name: "SuperAbpRegionLocations");

            migrationBuilder.DropTable(
                name: "SuperAbpStreets");

            migrationBuilder.DropTable(
                name: "SuperAbpVillages");
        }
    }
}
