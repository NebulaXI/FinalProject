using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiProject.Infrastructure.Migrations
{
    public partial class changeRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_CreatedByUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_AspNetUsers_CreatedByUserId",
                table: "Topics");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 12, 20, 9, 16, 620, DateTimeKind.Local).AddTicks(7846), new DateTime(2022, 12, 12, 20, 9, 16, 620, DateTimeKind.Local).AddTicks(7848) });

            migrationBuilder.UpdateData(
                table: "Advertisments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 12, 20, 9, 16, 620, DateTimeKind.Local).AddTicks(7851), new DateTime(2022, 12, 12, 20, 9, 16, 620, DateTimeKind.Local).AddTicks(7853) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 12, 20, 9, 16, 620, DateTimeKind.Local).AddTicks(7591));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 12, 12, 20, 9, 16, 620, DateTimeKind.Local).AddTicks(7595));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 12, 12, 20, 9, 16, 620, DateTimeKind.Local).AddTicks(7597));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 12, 20, 9, 16, 620, DateTimeKind.Local).AddTicks(7479), new DateTime(2022, 12, 12, 20, 9, 16, 620, DateTimeKind.Local).AddTicks(7520) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 12, 20, 9, 16, 620, DateTimeKind.Local).AddTicks(7527), new DateTime(2022, 12, 12, 20, 9, 16, 620, DateTimeKind.Local).AddTicks(7528) });

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_CreatedByUserId",
                table: "Products",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_AspNetUsers_CreatedByUserId",
                table: "Topics",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_CreatedByUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_AspNetUsers_CreatedByUserId",
                table: "Topics");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_CreatedByUserId",
                table: "Products",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_AspNetUsers_CreatedByUserId",
                table: "Topics",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
