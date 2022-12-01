using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiProject.Infrastructure.Migrations
{
    public partial class SeedForumData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_AspNetUsers_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(3500)", maxLength: 3500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "LastUpdated", "Title" },
                values: new object[] { 1, "d33b5866-1720-4e84-bfba-977e3a864f86", new DateTime(2022, 11, 28, 8, 19, 21, 84, DateTimeKind.Local).AddTicks(3153), new DateTime(2022, 11, 28, 8, 19, 21, 84, DateTimeKind.Local).AddTicks(3198), "First topic" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "LastUpdated", "Title" },
                values: new object[] { 2, "d33b5866-1720-4e84-bfba-977e3a864f86", new DateTime(2022, 11, 28, 8, 19, 21, 84, DateTimeKind.Local).AddTicks(3201), new DateTime(2022, 11, 28, 8, 19, 21, 84, DateTimeKind.Local).AddTicks(3203), "Second topic" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Date", "TopicId", "UserId" },
                values: new object[] { 1, "1 topic,1 comment", new DateTime(2022, 11, 28, 8, 19, 21, 84, DateTimeKind.Local).AddTicks(3282), 1, "d33b5866-1720-4e84-bfba-977e3a864f86" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Date", "TopicId", "UserId" },
                values: new object[] { 2, "1 topic,2 comment", new DateTime(2022, 11, 28, 8, 19, 21, 84, DateTimeKind.Local).AddTicks(3287), 1, "d33b5866-1720-4e84-bfba-977e3a864f86" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Date", "TopicId", "UserId" },
                values: new object[] { 3, "2 topic,1 comment", new DateTime(2022, 11, 28, 8, 19, 21, 84, DateTimeKind.Local).AddTicks(3289), 2, "d33b5866-1720-4e84-bfba-977e3a864f86" });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TopicId",
                table: "Posts",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_CreatedByUserId",
                table: "Topics",
                column: "CreatedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}
