using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactionService.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reaction",
                columns: table => new
                {
                    ReactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReactionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: true),
                    Month = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reaction", x => x.ReactionId);
                });

            migrationBuilder.CreateTable(
                name: "ReactionTypes",
                columns: table => new
                {
                    ReactionTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReactionTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReactionTypeImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReactionTypes", x => x.ReactionTypeID);
                });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "ReactionId", "Day", "Month", "ReactionTypeId", "UserId", "Year" },
                values: new object[,]
                {
                    { new Guid("d06e3c0a-0291-4dfd-b99f-07d0f6aa4501"), 12, 4, new Guid("435e5a56-67fa-4262-8175-0ac53e712b7b"), new Guid("b5104b9c-c94d-4a84-9aea-13a615358dab"), 2008 },
                    { new Guid("93f498c9-4eae-42b5-b9ef-f98e53fd5169"), 15, 5, new Guid("435e5a56-67fa-4262-8175-0ac53e712b7b"), new Guid("fe5bd367-0a45-44cb-8299-faa6fe2e632a"), 2005 }
                });

            migrationBuilder.InsertData(
                table: "ReactionTypes",
                columns: new[] { "ReactionTypeID", "ReactionTypeImage", "ReactionTypeName" },
                values: new object[,]
                {
                    { new Guid("77be3bf1-5df2-4fcb-a89a-dfebc0b69b1f"), "likeImage.png", "Like" },
                    { new Guid("435e5a56-67fa-4262-8175-0ac53e712b7b"), "dislikeImage.png", "Dislike" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reaction");

            migrationBuilder.DropTable(
                name: "ReactionTypes");
        }
    }
}
