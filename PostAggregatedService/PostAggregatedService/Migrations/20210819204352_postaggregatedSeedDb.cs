using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PostAggregatedService.Migrations
{
    public partial class postaggregatedSeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PostAggregated",
                columns: new[] { "PostAggregatedId", "NumberOfComments", "NumberOfDislikes", "NumberOfHearts", "NumberOfLikes", "NumberOfSmileys", "NumberOfVisits", "PostId" },
                values: new object[] { new Guid("d221da3e-f9d5-45d5-a44c-15479d3b7b21"), 10, 5, 6, 10, 1, 100, new Guid("71a1d81c-7fea-4e9a-bb29-541e165fc198") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PostAggregated",
                keyColumn: "PostAggregatedId",
                keyValue: new Guid("d221da3e-f9d5-45d5-a44c-15479d3b7b21"));
        }
    }
}
