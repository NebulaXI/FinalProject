using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiProject.Infrastructure.Migrations
{
    public partial class UpdateCityData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WebCamera",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "WebCamera",
                value: "https://www.banskoski.com/bg/webcams");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "WebCamera",
                value: "https://www.borovets-bg.com/en/page/info/lifts-trails/weather-webcams-avalanche-warning");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                column: "WebCamera",
                value: "http://free-webcambg.com/Pamporovo-07-webcam-live-online-camera-ski-tv-Snejanka-kameri-na-jivo-vremeto-weather.htm");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4,
                column: "WebCamera",
                value: "http://free-webcambg.com/Rilski-ezera-02-webcam-live-online-camera-hija-Pionerska-Panichishte-Rila-kameri-na-jivo-vremeto-weather.htm");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WebCamera",
                table: "Cities");
        }
    }
}
