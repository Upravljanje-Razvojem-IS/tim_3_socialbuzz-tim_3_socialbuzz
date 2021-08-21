using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PostAggregatedService.Migrations
{
    public partial class postaggregateddbmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostAggregated",
                columns: table => new
                {
                    PostAggregatedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfVisits = table.Column<int>(type: "int", nullable: true),
                    NumberOfComments = table.Column<int>(type: "int", nullable: true),
                    NumberOfLikes = table.Column<int>(type: "int", nullable: true),
                    NumberOfDislikes = table.Column<int>(type: "int", nullable: true),
                    NumberOfSmileys = table.Column<int>(type: "int", nullable: true),
                    NumberOfHearts = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostAggregated", x => x.PostAggregatedId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostAggregated");
        }
    }
}
