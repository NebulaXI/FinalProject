using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiProject.Infrastructure.Migrations
{
    public partial class updateCreationOfUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 12, 10, 14, 47, 556, DateTimeKind.Local).AddTicks(6008), new DateTime(2022, 12, 12, 10, 14, 47, 556, DateTimeKind.Local).AddTicks(6011) });

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 12, 10, 14, 47, 556, DateTimeKind.Local).AddTicks(6015), new DateTime(2022, 12, 12, 10, 14, 47, 556, DateTimeKind.Local).AddTicks(6016) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 12, 10, 14, 47, 556, DateTimeKind.Local).AddTicks(5762));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 12, 12, 10, 14, 47, 556, DateTimeKind.Local).AddTicks(5767));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 12, 12, 10, 14, 47, 556, DateTimeKind.Local).AddTicks(5769));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 12, 10, 14, 47, 556, DateTimeKind.Local).AddTicks(5641), new DateTime(2022, 12, 12, 10, 14, 47, 556, DateTimeKind.Local).AddTicks(5680) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 12, 10, 14, 47, 556, DateTimeKind.Local).AddTicks(5684), new DateTime(2022, 12, 12, 10, 14, 47, 556, DateTimeKind.Local).AddTicks(5685) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 11, 21, 23, 50, 987, DateTimeKind.Local).AddTicks(2560), new DateTime(2022, 12, 11, 21, 23, 50, 987, DateTimeKind.Local).AddTicks(2562) });

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 11, 21, 23, 50, 987, DateTimeKind.Local).AddTicks(2565), new DateTime(2022, 12, 11, 21, 23, 50, 987, DateTimeKind.Local).AddTicks(2566) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 11, 21, 23, 50, 987, DateTimeKind.Local).AddTicks(2292));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 12, 11, 21, 23, 50, 987, DateTimeKind.Local).AddTicks(2296));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 12, 11, 21, 23, 50, 987, DateTimeKind.Local).AddTicks(2299));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 11, 21, 23, 50, 987, DateTimeKind.Local).AddTicks(2162), new DateTime(2022, 12, 11, 21, 23, 50, 987, DateTimeKind.Local).AddTicks(2218) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 11, 21, 23, 50, 987, DateTimeKind.Local).AddTicks(2222), new DateTime(2022, 12, 11, 21, 23, 50, 987, DateTimeKind.Local).AddTicks(2223) });
        }
    }
}
