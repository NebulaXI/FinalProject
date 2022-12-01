using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiProject.Infrastructure.Migrations
{
    public partial class seedSlopes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Slopes",
                columns: new[] { "Id", "CityId", "PriceForSeasonAdult", "PriceForSeasonChildren", "PricePerDayAdult", "PricePerDayChildren" },
                values: new object[,]
                {
                    { 1, 1, 1500.00m, 350.00m, 80.00m, 25.00m },
                    { 2, 2, 1200.00m, 310.00m, 76.00m, 20.00m },
                    { 3, 3, 1410.00m, 340.00m, 80.00m, 20.00m },
                    { 4, 4, 500.00m, 120.00m, 32.00m, 15.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Slopes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
