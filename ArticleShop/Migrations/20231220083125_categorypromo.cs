using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArticleShop.Migrations
{
    /// <inheritdoc />
    public partial class categorypromo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsPromo",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsPromo", "Name" },
                values: new object[,]
                {
                    { new Guid("10681808-6e0d-4348-a6f7-e222bca0abf9"), false, "Food" },
                    { new Guid("10c241c9-e5af-4108-bfc6-a0d6071283ed"), false, "Computer Game" },
                    { new Guid("3cd222ae-65b0-42f5-98d2-0e44b3af3b57"), false, "Book" },
                    { new Guid("5d2d5561-c5ea-4bbe-a588-7272a78e1fa2"), false, "Board Game" },
                    { new Guid("70a40bc0-f522-470e-8f78-73b7565a5fe3"), false, "Furniture" },
                    { new Guid("7333d8e5-40f4-473a-8b01-7a76662a0104"), false, "Animals" },
                    { new Guid("83a2355c-1392-4deb-80e8-3375954bb47a"), false, "School" },
                    { new Guid("9b0cbbcd-f7a8-4c01-ab7f-63d43c49e2c2"), false, "Others" },
                    { new Guid("daa1648d-7509-40dc-9b75-ed4e90072507"), false, "Music" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "ExpiryDate", "ImagePath", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("7a5d46be-4b5d-418f-b371-0713b42da82f"), new Guid("daa1648d-7509-40dc-9b75-ed4e90072507"), new DateOnly(2034, 7, 7), "/image/no_image.jpg", "Flute coursebook", 10.00m },
                    { new Guid("8d167375-10ab-4b4a-a7ed-563c657acae6"), new Guid("5d2d5561-c5ea-4bbe-a588-7272a78e1fa2"), new DateOnly(2043, 1, 1), "/image/no_image.jpg", "Gloomhaven", 80.99m },
                    { new Guid("a39ad502-be57-4288-afd4-4e0d2c3373d0"), new Guid("7333d8e5-40f4-473a-8b01-7a76662a0104"), new DateOnly(2033, 12, 20), "/image/no_image.jpg", "Bird cage", 47.29m },
                    { new Guid("bd7a6d0b-7b23-4cbd-a497-522228878b6f"), new Guid("10681808-6e0d-4348-a6f7-e222bca0abf9"), new DateOnly(2023, 12, 20), "/image/no_image.jpg", "Chocolate bar", 2.34m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("7a5d46be-4b5d-418f-b371-0713b42da82f"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("8d167375-10ab-4b4a-a7ed-563c657acae6"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("a39ad502-be57-4288-afd4-4e0d2c3373d0"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("bd7a6d0b-7b23-4cbd-a497-522228878b6f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10c241c9-e5af-4108-bfc6-a0d6071283ed"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3cd222ae-65b0-42f5-98d2-0e44b3af3b57"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("70a40bc0-f522-470e-8f78-73b7565a5fe3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("83a2355c-1392-4deb-80e8-3375954bb47a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9b0cbbcd-f7a8-4c01-ab7f-63d43c49e2c2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10681808-6e0d-4348-a6f7-e222bca0abf9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5d2d5561-c5ea-4bbe-a588-7272a78e1fa2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7333d8e5-40f4-473a-8b01-7a76662a0104"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("daa1648d-7509-40dc-9b75-ed4e90072507"));

            migrationBuilder.DropColumn(
                name: "IsPromo",
                table: "Categories");

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
    }
}
