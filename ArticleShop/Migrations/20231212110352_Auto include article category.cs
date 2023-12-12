using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArticleShop.Migrations
{
    /// <inheritdoc />
    public partial class Autoincludearticlecategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0413852e-f5e3-4741-b76a-7c62b94fe22c"), "Animals" },
                    { new Guid("07c7453d-6c3c-492a-912e-0785423d3ec7"), "School" },
                    { new Guid("613416ee-1931-40a2-a6a4-dc2167c8d197"), "Food" },
                    { new Guid("9973e278-543f-48c4-9f3c-abe905ded94f"), "Board Game" },
                    { new Guid("a8906ad8-de4b-4844-a78b-63487e6f62ef"), "Book" },
                    { new Guid("b12e5e71-3b93-400f-8714-4c25a2eee14c"), "Music" },
                    { new Guid("c7ae053d-30be-4c81-b5ad-e339c16759a7"), "Computer Game" },
                    { new Guid("e17ecc3c-4d6d-46b4-9eec-053f71050970"), "Others" },
                    { new Guid("fdbccd1e-454d-49ed-adf5-51bd24894856"), "Furniture" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "ExpiryDate", "ImagePath", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("3e9d555a-51c5-4b42-ae0c-b9dc212a0283"), new Guid("b12e5e71-3b93-400f-8714-4c25a2eee14c"), new DateOnly(2034, 7, 7), null, "Flute coursebook", 10.00m },
                    { new Guid("a3e68cfe-868a-4fd8-947a-e9e5877febe5"), new Guid("613416ee-1931-40a2-a6a4-dc2167c8d197"), new DateOnly(2023, 12, 20), null, "Chocolate bar", 2.34m },
                    { new Guid("cb78fbe0-54a4-4440-a553-30e84d0ed605"), new Guid("0413852e-f5e3-4741-b76a-7c62b94fe22c"), new DateOnly(2033, 12, 20), null, "Bird cage", 47.29m },
                    { new Guid("f46c75b5-71ed-41a0-acc3-434cafd51388"), new Guid("9973e278-543f-48c4-9f3c-abe905ded94f"), new DateOnly(2043, 1, 1), null, "Gloomhaven", 80.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("3e9d555a-51c5-4b42-ae0c-b9dc212a0283"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("a3e68cfe-868a-4fd8-947a-e9e5877febe5"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("cb78fbe0-54a4-4440-a553-30e84d0ed605"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f46c75b5-71ed-41a0-acc3-434cafd51388"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("07c7453d-6c3c-492a-912e-0785423d3ec7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a8906ad8-de4b-4844-a78b-63487e6f62ef"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c7ae053d-30be-4c81-b5ad-e339c16759a7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e17ecc3c-4d6d-46b4-9eec-053f71050970"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fdbccd1e-454d-49ed-adf5-51bd24894856"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0413852e-f5e3-4741-b76a-7c62b94fe22c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("613416ee-1931-40a2-a6a4-dc2167c8d197"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9973e278-543f-48c4-9f3c-abe905ded94f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b12e5e71-3b93-400f-8714-4c25a2eee14c"));

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
    }
}
