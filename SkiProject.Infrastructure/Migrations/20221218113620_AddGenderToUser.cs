using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiProject.Infrastructure.Migrations
{
    public partial class AddGenderToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 18, 13, 36, 20, 126, DateTimeKind.Local).AddTicks(5568), new DateTime(2022, 12, 18, 13, 36, 20, 126, DateTimeKind.Local).AddTicks(5570) });

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 18, 13, 36, 20, 126, DateTimeKind.Local).AddTicks(5573), new DateTime(2022, 12, 18, 13, 36, 20, 126, DateTimeKind.Local).AddTicks(5575) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "WebCamera",
                value: "https://weather-webcam.eu/borovec-hotel-ela-online-kamea-rila-na-jivo/");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 18, 13, 36, 20, 126, DateTimeKind.Local).AddTicks(5324));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 12, 18, 13, 36, 20, 126, DateTimeKind.Local).AddTicks(5328));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 12, 18, 13, 36, 20, 126, DateTimeKind.Local).AddTicks(5330));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 18, 13, 36, 20, 126, DateTimeKind.Local).AddTicks(5224), new DateTime(2022, 12, 18, 13, 36, 20, 126, DateTimeKind.Local).AddTicks(5256) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 18, 13, 36, 20, 126, DateTimeKind.Local).AddTicks(5260), new DateTime(2022, 12, 18, 13, 36, 20, 126, DateTimeKind.Local).AddTicks(5262) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 12, 21, 49, 15, 521, DateTimeKind.Local).AddTicks(8019), new DateTime(2022, 12, 12, 21, 49, 15, 521, DateTimeKind.Local).AddTicks(8024) });

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 12, 21, 49, 15, 521, DateTimeKind.Local).AddTicks(8029), new DateTime(2022, 12, 12, 21, 49, 15, 521, DateTimeKind.Local).AddTicks(8031) });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "WebCamera",
                value: "https://www.borovets-bg.com/en/page/info/lifts-trails/weather-webcams-avalanche-warning");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 12, 21, 49, 15, 521, DateTimeKind.Local).AddTicks(7605));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 12, 12, 21, 49, 15, 521, DateTimeKind.Local).AddTicks(7611));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 12, 12, 21, 49, 15, 521, DateTimeKind.Local).AddTicks(7614));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 12, 21, 49, 15, 521, DateTimeKind.Local).AddTicks(7452), new DateTime(2022, 12, 12, 21, 49, 15, 521, DateTimeKind.Local).AddTicks(7503) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 12, 21, 49, 15, 521, DateTimeKind.Local).AddTicks(7510), new DateTime(2022, 12, 12, 21, 49, 15, 521, DateTimeKind.Local).AddTicks(7512) });
        }
    }
}
