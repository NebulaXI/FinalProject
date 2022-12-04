using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiProject.Infrastructure.Migrations
{
    public partial class AddCountOfCommentsToTopicTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentsCount",
                table: "Topics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 3, 19, 38, 37, 164, DateTimeKind.Local).AddTicks(3452));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 12, 3, 19, 38, 37, 164, DateTimeKind.Local).AddTicks(3460));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 12, 3, 19, 38, 37, 164, DateTimeKind.Local).AddTicks(3462));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CommentsCount", "CreatedOn", "LastUpdated" },
                values: new object[] { 3, new DateTime(2022, 12, 3, 19, 38, 37, 164, DateTimeKind.Local).AddTicks(3355), new DateTime(2022, 12, 3, 19, 38, 37, 164, DateTimeKind.Local).AddTicks(3385) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CommentsCount", "CreatedOn", "LastUpdated" },
                values: new object[] { 1, new DateTime(2022, 12, 3, 19, 38, 37, 164, DateTimeKind.Local).AddTicks(3391), new DateTime(2022, 12, 3, 19, 38, 37, 164, DateTimeKind.Local).AddTicks(3393) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentsCount",
                table: "Topics");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 11, 28, 8, 19, 21, 84, DateTimeKind.Local).AddTicks(3282));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 11, 28, 8, 19, 21, 84, DateTimeKind.Local).AddTicks(3287));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 11, 28, 8, 19, 21, 84, DateTimeKind.Local).AddTicks(3289));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 28, 8, 19, 21, 84, DateTimeKind.Local).AddTicks(3153), new DateTime(2022, 11, 28, 8, 19, 21, 84, DateTimeKind.Local).AddTicks(3198) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 11, 28, 8, 19, 21, 84, DateTimeKind.Local).AddTicks(3201), new DateTime(2022, 11, 28, 8, 19, 21, 84, DateTimeKind.Local).AddTicks(3203) });
        }
    }
}
