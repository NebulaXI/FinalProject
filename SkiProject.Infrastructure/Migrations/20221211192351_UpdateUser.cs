using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiProject.Infrastructure.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderId",
                table: "Messages");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
