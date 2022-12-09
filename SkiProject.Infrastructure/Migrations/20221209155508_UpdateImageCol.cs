using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiProject.Infrastructure.Migrations
{
    public partial class UpdateImageCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Advertisments",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 9, 17, 55, 8, 360, DateTimeKind.Local).AddTicks(940), new DateTime(2022, 12, 9, 17, 55, 8, 360, DateTimeKind.Local).AddTicks(943) });

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 9, 17, 55, 8, 360, DateTimeKind.Local).AddTicks(947), new DateTime(2022, 12, 9, 17, 55, 8, 360, DateTimeKind.Local).AddTicks(948) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 9, 17, 55, 8, 360, DateTimeKind.Local).AddTicks(674));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 12, 9, 17, 55, 8, 360, DateTimeKind.Local).AddTicks(678));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 12, 9, 17, 55, 8, 360, DateTimeKind.Local).AddTicks(680));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 9, 17, 55, 8, 360, DateTimeKind.Local).AddTicks(516), new DateTime(2022, 12, 9, 17, 55, 8, 360, DateTimeKind.Local).AddTicks(551) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 9, 17, 55, 8, 360, DateTimeKind.Local).AddTicks(602), new DateTime(2022, 12, 9, 17, 55, 8, 360, DateTimeKind.Local).AddTicks(604) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Advertisments");

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 9, 17, 27, 56, 747, DateTimeKind.Local).AddTicks(2561), new DateTime(2022, 12, 9, 17, 27, 56, 747, DateTimeKind.Local).AddTicks(2564) });

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 9, 17, 27, 56, 747, DateTimeKind.Local).AddTicks(2568), new DateTime(2022, 12, 9, 17, 27, 56, 747, DateTimeKind.Local).AddTicks(2570) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 9, 17, 27, 56, 747, DateTimeKind.Local).AddTicks(2230));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 12, 9, 17, 27, 56, 747, DateTimeKind.Local).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 12, 9, 17, 27, 56, 747, DateTimeKind.Local).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 9, 17, 27, 56, 747, DateTimeKind.Local).AddTicks(2084), new DateTime(2022, 12, 9, 17, 27, 56, 747, DateTimeKind.Local).AddTicks(2149) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 9, 17, 27, 56, 747, DateTimeKind.Local).AddTicks(2156), new DateTime(2022, 12, 9, 17, 27, 56, 747, DateTimeKind.Local).AddTicks(2158) });
        }
    }
}
