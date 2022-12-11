using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiProject.Infrastructure.Migrations
{
    public partial class addDateToMessageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Messages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 11, 12, 46, 47, 435, DateTimeKind.Local).AddTicks(9370), new DateTime(2022, 12, 11, 12, 46, 47, 435, DateTimeKind.Local).AddTicks(9373) });

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 11, 12, 46, 47, 435, DateTimeKind.Local).AddTicks(9376), new DateTime(2022, 12, 11, 12, 46, 47, 435, DateTimeKind.Local).AddTicks(9377) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 11, 12, 46, 47, 435, DateTimeKind.Local).AddTicks(9086));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 12, 11, 12, 46, 47, 435, DateTimeKind.Local).AddTicks(9089));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 12, 11, 12, 46, 47, 435, DateTimeKind.Local).AddTicks(9091));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 11, 12, 46, 47, 435, DateTimeKind.Local).AddTicks(8984), new DateTime(2022, 12, 11, 12, 46, 47, 435, DateTimeKind.Local).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 11, 12, 46, 47, 435, DateTimeKind.Local).AddTicks(9024), new DateTime(2022, 12, 11, 12, 46, 47, 435, DateTimeKind.Local).AddTicks(9025) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Messages");

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 10, 16, 26, 23, 944, DateTimeKind.Local).AddTicks(2369), new DateTime(2022, 12, 10, 16, 26, 23, 944, DateTimeKind.Local).AddTicks(2372) });

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 10, 16, 26, 23, 944, DateTimeKind.Local).AddTicks(2376), new DateTime(2022, 12, 10, 16, 26, 23, 944, DateTimeKind.Local).AddTicks(2377) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 10, 16, 26, 23, 944, DateTimeKind.Local).AddTicks(2099));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 12, 10, 16, 26, 23, 944, DateTimeKind.Local).AddTicks(2104));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 12, 10, 16, 26, 23, 944, DateTimeKind.Local).AddTicks(2105));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 10, 16, 26, 23, 944, DateTimeKind.Local).AddTicks(1994), new DateTime(2022, 12, 10, 16, 26, 23, 944, DateTimeKind.Local).AddTicks(2030) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 10, 16, 26, 23, 944, DateTimeKind.Local).AddTicks(2034), new DateTime(2022, 12, 10, 16, 26, 23, 944, DateTimeKind.Local).AddTicks(2035) });
        }
    }
}
