using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArticleShop.Migrations
{
    /// <inheritdoc />
    public partial class NonNullableImageSrc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("09675280-9054-4898-9da2-365262ed21a4"), "Computer Game" },
                    { new Guid("172bccc0-2257-4088-8b78-830facaaa93c"), "Furniture" },
                    { new Guid("2099daed-67ff-4b0d-9a74-a692ffdbde55"), "Board Game" },
                    { new Guid("358d7e61-88dd-4350-9798-cd13e41733f3"), "Others" },
                    { new Guid("3d8610e3-fd6b-409f-b948-872ad71f59f5"), "Animals" },
                    { new Guid("67f9fcb3-69dd-4660-a4ff-3108d70d2acd"), "Food" },
                    { new Guid("87753d74-5ddb-4f27-8328-cf71aeeb9b95"), "Book" },
                    { new Guid("96ad21ee-9d07-48bf-a17f-b76ee1968143"), "School" },
                    { new Guid("caf462ec-5b6e-40fc-bdca-fdd01d137f64"), "Music" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "ExpiryDate", "ImagePath", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("2f8113ec-f2d7-4a69-a464-86f15664d440"), new Guid("2099daed-67ff-4b0d-9a74-a692ffdbde55"), new DateOnly(2043, 1, 1), "/image/no_image.jpg", "Gloomhaven", 80.99m },
                    { new Guid("85aebc86-e06c-4ac7-a0ea-260df74cad72"), new Guid("caf462ec-5b6e-40fc-bdca-fdd01d137f64"), new DateOnly(2034, 7, 7), "/image/no_image.jpg", "Flute coursebook", 10.00m },
                    { new Guid("b534d835-40cf-4f98-af07-5971a89a05aa"), new Guid("3d8610e3-fd6b-409f-b948-872ad71f59f5"), new DateOnly(2033, 12, 20), "/image/no_image.jpg", "Bird cage", 47.29m },
                    { new Guid("ee972760-d8c8-493e-9df3-f48411f46332"), new Guid("67f9fcb3-69dd-4660-a4ff-3108d70d2acd"), new DateOnly(2023, 12, 20), "/image/no_image.jpg", "Chocolate bar", 2.34m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("2f8113ec-f2d7-4a69-a464-86f15664d440"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("85aebc86-e06c-4ac7-a0ea-260df74cad72"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("b534d835-40cf-4f98-af07-5971a89a05aa"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("ee972760-d8c8-493e-9df3-f48411f46332"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("09675280-9054-4898-9da2-365262ed21a4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("172bccc0-2257-4088-8b78-830facaaa93c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("358d7e61-88dd-4350-9798-cd13e41733f3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("87753d74-5ddb-4f27-8328-cf71aeeb9b95"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("96ad21ee-9d07-48bf-a17f-b76ee1968143"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2099daed-67ff-4b0d-9a74-a692ffdbde55"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3d8610e3-fd6b-409f-b948-872ad71f59f5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("67f9fcb3-69dd-4660-a4ff-3108d70d2acd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("caf462ec-5b6e-40fc-bdca-fdd01d137f64"));

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
