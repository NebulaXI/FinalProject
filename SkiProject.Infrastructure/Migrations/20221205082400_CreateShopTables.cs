using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkiProject.Infrastructure.Migrations
{
    public partial class CreateShopTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfGender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(3500)", maxLength: 3500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Advertisments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertisments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advertisments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "NameOfCategory" },
                values: new object[,]
                {
                    { 1, "Jackets" },
                    { 2, "Pants" },
                    { 3, "Shoes" },
                    { 4, "Glasses" },
                    { 5, "Helmets" },
                    { 6, "Underwear" },
                    { 7, "Skis" },
                    { 8, "Snowboards" },
                    { 9, "Others" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "NameOfGender" },
                values: new object[,]
                {
                    { 1, "Kids" },
                    { 2, "Women" },
                    { 3, "Men" },
                    { 4, "Unisex" }
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 5, 10, 23, 59, 608, DateTimeKind.Local).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 12, 5, 10, 23, 59, 608, DateTimeKind.Local).AddTicks(4931));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 12, 5, 10, 23, 59, 608, DateTimeKind.Local).AddTicks(4934));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 5, 10, 23, 59, 608, DateTimeKind.Local).AddTicks(4724), new DateTime(2022, 12, 5, 10, 23, 59, 608, DateTimeKind.Local).AddTicks(4798) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 5, 10, 23, 59, 608, DateTimeKind.Local).AddTicks(4802), new DateTime(2022, 12, 5, 10, 23, 59, 608, DateTimeKind.Local).AddTicks(4803) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "GenderId", "Price" },
                values: new object[] { 1, 1, "Woman jacket", 2, 120.0m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "GenderId", "Price" },
                values: new object[] { 2, 2, "Men pants", 3, 80.0m });

            migrationBuilder.InsertData(
                table: "Advertisments",
                columns: new[] { "Id", "CreatedOn", "LastUpdatedOn", "ProductId", "Title", "UserId" },
                values: new object[] { 1, new DateTime(2022, 12, 5, 10, 23, 59, 608, DateTimeKind.Local).AddTicks(5182), new DateTime(2022, 12, 5, 10, 23, 59, 608, DateTimeKind.Local).AddTicks(5184), 1, "Woman jacket", "d33b5866-1720-4e84-bfba-977e3a864f86" });

            migrationBuilder.InsertData(
                table: "Advertisments",
                columns: new[] { "Id", "CreatedOn", "LastUpdatedOn", "ProductId", "Title", "UserId" },
                values: new object[] { 2, new DateTime(2022, 12, 5, 10, 23, 59, 608, DateTimeKind.Local).AddTicks(5188), new DateTime(2022, 12, 5, 10, 23, 59, 608, DateTimeKind.Local).AddTicks(5189), 2, "Men pants", "d33b5866-1720-4e84-bfba-977e3a864f86" });

            migrationBuilder.CreateIndex(
                name: "IX_Topics_Title",
                table: "Topics",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Advertisments_ProductId",
                table: "Advertisments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisments_Title",
                table: "Advertisments",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Advertisments_UserId",
                table: "Advertisments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GenderId",
                table: "Products",
                column: "GenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisments");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_Topics_Title",
                table: "Topics");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 12, 3, 19, 38, 37, 164, DateTimeKind.Local).AddTicks(3452));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 12, 3, 19, 38, 37, 164, DateTimeKind.Local).AddTicks(3460));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 12, 3, 19, 38, 37, 164, DateTimeKind.Local).AddTicks(3462));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 3, 19, 38, 37, 164, DateTimeKind.Local).AddTicks(3355), new DateTime(2022, 12, 3, 19, 38, 37, 164, DateTimeKind.Local).AddTicks(3385) });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastUpdated" },
                values: new object[] { new DateTime(2022, 12, 3, 19, 38, 37, 164, DateTimeKind.Local).AddTicks(3391), new DateTime(2022, 12, 3, 19, 38, 37, 164, DateTimeKind.Local).AddTicks(3393) });
        }
    }
}
