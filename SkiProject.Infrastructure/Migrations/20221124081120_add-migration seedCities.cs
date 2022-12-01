using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiProject.Infrastructure.Migrations
{
    public partial class addmigrationseedCities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaceToStays_Cities_CityId",
                table: "PlaceToStays");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_PlaceToStays_PlaceToStayId",
                table: "Reservations");

            migrationBuilder.CreateTable(
                name: "Slopes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PricePerDayChildren = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PricePerDayAdult = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PriceForSeasonChildren = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PriceForSeasonAdult = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slopes_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bansko" },
                    { 2, "Borovets" },
                    { 3, "Pamporovo" },
                    { 4, "Panichishte" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Slopes_CityId",
                table: "Slopes",
                column: "CityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceToStays_Cities_CityId",
                table: "PlaceToStays",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_PlaceToStays_PlaceToStayId",
                table: "Reservations",
                column: "PlaceToStayId",
                principalTable: "PlaceToStays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaceToStays_Cities_CityId",
                table: "PlaceToStays");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_PlaceToStays_PlaceToStayId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "Slopes");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceToStays_Cities_CityId",
                table: "PlaceToStays",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_PlaceToStays_PlaceToStayId",
                table: "Reservations",
                column: "PlaceToStayId",
                principalTable: "PlaceToStays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
