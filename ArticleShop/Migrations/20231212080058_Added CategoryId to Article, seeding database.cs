using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArticleShop.Migrations
{
    /// <inheritdoc />
    public partial class AddedCategoryIdtoArticleseedingdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1dc7885c-e02f-4851-8eb5-7e783c8d95b7"), "Food" },
                    { new Guid("2355175a-146b-4441-a823-11cbe64136d7"), "Book" },
                    { new Guid("505e7803-18c2-4514-88e0-cf4facff31bb"), "Others" },
                    { new Guid("52cb6d95-dcc8-45d9-94d2-9a3e9c5fb546"), "Board Game" },
                    { new Guid("5f50a9d1-5480-4f08-b831-6a0e1b77e7ff"), "School" },
                    { new Guid("67fc1d0a-2975-4399-a536-7d3d7f712981"), "Furniture" },
                    { new Guid("6a86bf12-1da4-4666-ac3c-5a00fb4157b7"), "Animals" },
                    { new Guid("cd92cd07-b076-4b09-9c17-3502b2467e07"), "Music" },
                    { new Guid("d1191d25-929a-4067-829c-05258ab0c81c"), "Computer Game" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "ExpiryDate", "ImagePath", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("7086f7de-9d33-4406-a98e-59f045dc4553"), new Guid("6a86bf12-1da4-4666-ac3c-5a00fb4157b7"), new DateOnly(2033, 12, 20), null, "Bird cage", 47.29m },
                    { new Guid("82c42e41-cd24-4a6a-b84d-682c34400bfb"), new Guid("52cb6d95-dcc8-45d9-94d2-9a3e9c5fb546"), new DateOnly(2043, 1, 1), null, "Gloomhaven", 80.99m },
                    { new Guid("db15d3dd-eb03-4a50-ac75-1c6dccb4f93a"), new Guid("1dc7885c-e02f-4851-8eb5-7e783c8d95b7"), new DateOnly(2023, 12, 20), null, "Chocolate bar", 2.34m },
                    { new Guid("e295a6c9-efe2-4ecf-8100-a2192d29f096"), new Guid("cd92cd07-b076-4b09-9c17-3502b2467e07"), new DateOnly(2034, 7, 7), null, "Flute coursebook", 10.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("7086f7de-9d33-4406-a98e-59f045dc4553"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("82c42e41-cd24-4a6a-b84d-682c34400bfb"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("db15d3dd-eb03-4a50-ac75-1c6dccb4f93a"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("e295a6c9-efe2-4ecf-8100-a2192d29f096"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2355175a-146b-4441-a823-11cbe64136d7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("505e7803-18c2-4514-88e0-cf4facff31bb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5f50a9d1-5480-4f08-b831-6a0e1b77e7ff"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("67fc1d0a-2975-4399-a536-7d3d7f712981"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d1191d25-929a-4067-829c-05258ab0c81c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1dc7885c-e02f-4851-8eb5-7e783c8d95b7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("52cb6d95-dcc8-45d9-94d2-9a3e9c5fb546"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6a86bf12-1da4-4666-ac3c-5a00fb4157b7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cd92cd07-b076-4b09-9c17-3502b2467e07"));
        }
    }
}
