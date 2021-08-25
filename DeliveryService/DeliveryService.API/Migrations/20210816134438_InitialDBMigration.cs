using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryService.API.Migrations
{
    public partial class InitialDBMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceDistances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinimalDistance = table.Column<int>(type: "int", nullable: false),
                    MaximalDistance = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceDistances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeightRanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinimalWeight = table.Column<float>(type: "real", nullable: false),
                    MaximalWeight = table.Column<float>(type: "real", nullable: false),
                    PriceCoefficient = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightRanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Pieces = table.Column<int>(type: "int", nullable: false),
                    TotalWeight = table.Column<double>(type: "float", nullable: false),
                    TotalPriceWithWeightAndDistance = table.Column<double>(type: "float", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    WeightRangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceDistanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Addresses_FromAddressId",
                        column: x => x.FromAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Addresses_ToAddressId",
                        column: x => x.ToAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sales_PriceDistances_PriceDistanceId",
                        column: x => x.PriceDistanceId,
                        principalTable: "PriceDistances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_WeightRanges_WeightRangeId",
                        column: x => x.WeightRangeId,
                        principalTable: "WeightRanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_FromAddressId",
                table: "Sales",
                column: "FromAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_PriceDistanceId",
                table: "Sales",
                column: "PriceDistanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ToAddressId",
                table: "Sales",
                column: "ToAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_WeightRangeId",
                table: "Sales",
                column: "WeightRangeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "PriceDistances");

            migrationBuilder.DropTable(
                name: "WeightRanges");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
