using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiProject.Infrastructure.Migrations
{
    public partial class UserCreatedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ProfileCreatedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 12, 19, 34, 2, 266, DateTimeKind.Local).AddTicks(7506), new DateTime(2022, 12, 12, 19, 34, 2, 266, DateTimeKind.Local).AddTicks(7508) });

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 12, 19, 34, 2, 266, DateTimeKind.Local).AddTicks(7511), new DateTime(2022, 12, 12, 19, 34, 2, 266, DateTimeKind.Local).AddTicks(7513) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 12, 19, 34, 2, 266, DateTimeKind.Local).AddTicks(7251));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 12, 12, 19, 34, 2, 266, DateTimeKind.Local).AddTicks(7256));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 12, 12, 19, 34, 2, 266, DateTimeKind.Local).AddTicks(7258));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 12, 19, 34, 2, 266, DateTimeKind.Local).AddTicks(7112), new DateTime(2022, 12, 12, 19, 34, 2, 266, DateTimeKind.Local).AddTicks(7145) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 12, 19, 34, 2, 266, DateTimeKind.Local).AddTicks(7149), new DateTime(2022, 12, 12, 19, 34, 2, 266, DateTimeKind.Local).AddTicks(7151) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileCreatedOn",
                table: "AspNetUsers");

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
    }
}
