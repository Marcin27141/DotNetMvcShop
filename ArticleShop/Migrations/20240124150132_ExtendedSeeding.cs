using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArticleShop.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("2cd77744-bab8-45ad-88c6-5c9b502d9df7"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("ddf5eb23-3033-490f-864b-12ed01b1a37a"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f13b30a7-b949-4ca2-97df-88715e30fa60"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f72a0115-3215-40bb-b8cc-3120b2358366"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("13da4819-97aa-426d-ba4e-2ba9869fbd1f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("20f908c4-006e-42ba-97c0-fee81a16d25f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2d83fc07-b0a0-4b43-9016-ece56a5ad924"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3e188f07-5f2c-4c07-a447-b63fa54069f3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b22df679-b283-429a-87cb-2b2ac49ceb00"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("75058f45-df6e-4e8e-8456-d083732c633d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a5c0f677-070e-4900-9428-b5cf75afaf56"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bdf3bb32-0bfc-47a8-8f82-4905ef89cb36"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d171dd54-b286-4faf-8094-103e25c66076"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsPromo", "Name" },
                values: new object[,]
                {
                    { new Guid("10642812-da15-44dd-92e8-41c8007e2b7b"), false, "Board Game" },
                    { new Guid("48785f02-5491-4bb7-a051-51c8f5883650"), false, "Animals" },
                    { new Guid("7a8697a6-1a52-4c38-b698-eaa4fa908955"), false, "Others" },
                    { new Guid("94e0c3ed-917d-4911-a469-f3a8916fd34c"), false, "School" },
                    { new Guid("b9c80e67-698a-4a6f-a980-af1b14b673a6"), false, "Computer Game" },
                    { new Guid("ca9c31b4-80b7-43ef-ab74-65affc726ce5"), false, "Furniture" },
                    { new Guid("d5ac95c8-c8a4-4e4a-a364-266db8362152"), false, "Music" },
                    { new Guid("d772208c-39f3-4e46-a454-00ee849ecb32"), false, "Food" },
                    { new Guid("fd4b1015-844d-4aae-9fa7-a83a7213bfa5"), false, "Book" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "ExpiryDate", "ImagePath", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("1a93aaaa-cd5c-40ff-9318-3c1b97564eee"), new Guid("d5ac95c8-c8a4-4e4a-a364-266db8362152"), new DateOnly(2027, 1, 1), "/image/no_image.jpg", "Trumpet", 27.00m },
                    { new Guid("1e82b774-0ab1-4c12-9399-e69121e07382"), new Guid("d5ac95c8-c8a4-4e4a-a364-266db8362152"), new DateOnly(2034, 7, 7), "/image/no_image.jpg", "Flute coursebook", 10.00m },
                    { new Guid("221a0318-3994-4e56-a55f-57a502c647cd"), new Guid("48785f02-5491-4bb7-a051-51c8f5883650"), new DateOnly(2033, 12, 20), "/image/no_image.jpg", "Dog collar", 29.10m },
                    { new Guid("301cc0c9-0a74-4d57-a590-4a715a0e8250"), new Guid("d772208c-39f3-4e46-a454-00ee849ecb32"), new DateOnly(2023, 12, 20), "/image/no_image.jpg", "Chocolate bar", 2.34m },
                    { new Guid("553daff2-03df-4126-ab17-c731a352ec77"), new Guid("d5ac95c8-c8a4-4e4a-a364-266db8362152"), new DateOnly(2027, 1, 1), "/image/no_image.jpg", "Guitar", 100.00m },
                    { new Guid("57ae92a3-0ce4-4dd6-90df-b8431e840aeb"), new Guid("10642812-da15-44dd-92e8-41c8007e2b7b"), new DateOnly(2043, 1, 1), "/image/no_image.jpg", "Gloomhaven", 80.99m },
                    { new Guid("76de2ad3-58f8-4823-994d-80e7e2d99d91"), new Guid("48785f02-5491-4bb7-a051-51c8f5883650"), new DateOnly(2033, 12, 20), "/image/no_image.jpg", "Bird cage", 47.29m },
                    { new Guid("7c2e49a8-037f-4604-8e41-077dfb6d1c5b"), new Guid("10642812-da15-44dd-92e8-41c8007e2b7b"), new DateOnly(2033, 1, 1), "/image/no_image.jpg", "Ark Nova", 75.28m },
                    { new Guid("7cabe173-6454-464d-a24e-045235801846"), new Guid("10642812-da15-44dd-92e8-41c8007e2b7b"), new DateOnly(2029, 1, 1), "/image/no_image.jpg", "Wingspan", 42.68m },
                    { new Guid("8e66d6eb-b329-4491-ad42-923ce8e6b638"), new Guid("48785f02-5491-4bb7-a051-51c8f5883650"), new DateOnly(2026, 5, 20), "/image/no_image.jpg", "Leash", 12.00m },
                    { new Guid("d934bdb2-7077-44dd-a254-9024df5d3a23"), new Guid("d772208c-39f3-4e46-a454-00ee849ecb32"), new DateOnly(2024, 1, 1), "/image/no_image.jpg", "Spaghetti", 9.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1a93aaaa-cd5c-40ff-9318-3c1b97564eee"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("1e82b774-0ab1-4c12-9399-e69121e07382"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("221a0318-3994-4e56-a55f-57a502c647cd"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("301cc0c9-0a74-4d57-a590-4a715a0e8250"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("553daff2-03df-4126-ab17-c731a352ec77"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("57ae92a3-0ce4-4dd6-90df-b8431e840aeb"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("76de2ad3-58f8-4823-994d-80e7e2d99d91"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("7c2e49a8-037f-4604-8e41-077dfb6d1c5b"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("7cabe173-6454-464d-a24e-045235801846"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("8e66d6eb-b329-4491-ad42-923ce8e6b638"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("d934bdb2-7077-44dd-a254-9024df5d3a23"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7a8697a6-1a52-4c38-b698-eaa4fa908955"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("94e0c3ed-917d-4911-a469-f3a8916fd34c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b9c80e67-698a-4a6f-a980-af1b14b673a6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ca9c31b4-80b7-43ef-ab74-65affc726ce5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fd4b1015-844d-4aae-9fa7-a83a7213bfa5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10642812-da15-44dd-92e8-41c8007e2b7b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("48785f02-5491-4bb7-a051-51c8f5883650"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d5ac95c8-c8a4-4e4a-a364-266db8362152"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d772208c-39f3-4e46-a454-00ee849ecb32"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsPromo", "Name" },
                values: new object[,]
                {
                    { new Guid("13da4819-97aa-426d-ba4e-2ba9869fbd1f"), false, "Computer Game" },
                    { new Guid("20f908c4-006e-42ba-97c0-fee81a16d25f"), false, "Book" },
                    { new Guid("2d83fc07-b0a0-4b43-9016-ece56a5ad924"), false, "Furniture" },
                    { new Guid("3e188f07-5f2c-4c07-a447-b63fa54069f3"), false, "School" },
                    { new Guid("75058f45-df6e-4e8e-8456-d083732c633d"), false, "Board Game" },
                    { new Guid("a5c0f677-070e-4900-9428-b5cf75afaf56"), false, "Music" },
                    { new Guid("b22df679-b283-429a-87cb-2b2ac49ceb00"), false, "Others" },
                    { new Guid("bdf3bb32-0bfc-47a8-8f82-4905ef89cb36"), false, "Animals" },
                    { new Guid("d171dd54-b286-4faf-8094-103e25c66076"), false, "Food" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "ExpiryDate", "ImagePath", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("2cd77744-bab8-45ad-88c6-5c9b502d9df7"), new Guid("d171dd54-b286-4faf-8094-103e25c66076"), new DateOnly(2023, 12, 20), "/image/no_image.jpg", "Chocolate bar", 2.34m },
                    { new Guid("ddf5eb23-3033-490f-864b-12ed01b1a37a"), new Guid("75058f45-df6e-4e8e-8456-d083732c633d"), new DateOnly(2043, 1, 1), "/image/no_image.jpg", "Gloomhaven", 80.99m },
                    { new Guid("f13b30a7-b949-4ca2-97df-88715e30fa60"), new Guid("a5c0f677-070e-4900-9428-b5cf75afaf56"), new DateOnly(2034, 7, 7), "/image/no_image.jpg", "Flute coursebook", 10.00m },
                    { new Guid("f72a0115-3215-40bb-b8cc-3120b2358366"), new Guid("bdf3bb32-0bfc-47a8-8f82-4905ef89cb36"), new DateOnly(2033, 12, 20), "/image/no_image.jpg", "Bird cage", 47.29m }
                });
        }
    }
}
