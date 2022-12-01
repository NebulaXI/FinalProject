using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiProject.Infrastructure.Migrations
{
    public partial class seedHotels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PlaceToStays",
                columns: new[] { "Id", "Capacity", "CityId", "Name", "PricePerNightForAPerson" },
                values: new object[,]
                {
                    { 1, 300, 1, "Hotel Mura", 150.00m },
                    { 2, 300, 1, "Hotel Saint George", 110.00m },
                    { 3, 300, 1, "Evergreen", 140.00m },
                    { 4, 300, 2, "Hotel Lion", 150.00m },
                    { 5, 230, 2, "Hotel Iglika", 120.00m },
                    { 6, 120, 2, "Hotel Breza", 80.00m },
                    { 7, 70, 3, "Complex Malina", 120.00m },
                    { 8, 230, 3, "Hotel Snezhanka", 160.00m },
                    { 9, 250, 3, "Hotel Perelik", 140.00m },
                    { 10, 40, 4, "Hotel Magnoliya", 30.00m },
                    { 11, 170, 4, "103 Alpine Hotel", 100.00m },
                    { 12, 90, 4, "Hotel Panorama", 60.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlaceToStays",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlaceToStays",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlaceToStays",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PlaceToStays",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PlaceToStays",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PlaceToStays",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PlaceToStays",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PlaceToStays",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PlaceToStays",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PlaceToStays",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PlaceToStays",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PlaceToStays",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
