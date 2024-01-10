using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopRazor.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPromo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsPromo", "Name" },
                values: new object[,]
                {
                    { new Guid("057bb5d8-5b20-4a99-a328-8b971274b822"), false, "Furniture" },
                    { new Guid("0b0d0723-76fd-4d1c-a715-a70ea6063450"), false, "School" },
                    { new Guid("0b68c20d-d1db-42a4-ba38-655c2ffe3d77"), false, "Book" },
                    { new Guid("198722dc-c10a-4842-acb1-974721c6f24a"), false, "Board Game" },
                    { new Guid("47242800-2bdd-4b64-a508-0890e84adf8e"), false, "Others" },
                    { new Guid("551257be-8a7f-48bc-8363-188a4cc1f5c2"), false, "Computer Game" },
                    { new Guid("59aa8dfe-04e7-4a4b-8618-10c003c69824"), false, "Food" },
                    { new Guid("60a0c724-b255-43fe-88c2-4148385cd1a6"), false, "Music" },
                    { new Guid("a5ed66e8-0c88-4690-a5b1-4192938e3584"), false, "Animals" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "ExpiryDate", "ImagePath", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("37c04cea-2308-43ff-b9e1-e6cf73c228ea"), new Guid("198722dc-c10a-4842-acb1-974721c6f24a"), new DateOnly(2043, 1, 1), "/image/no_image.jpg", "Gloomhaven", 80.99m },
                    { new Guid("38a77687-d00c-4085-9cce-d2a92e759e23"), new Guid("a5ed66e8-0c88-4690-a5b1-4192938e3584"), new DateOnly(2033, 12, 20), "/image/no_image.jpg", "Bird cage", 47.29m },
                    { new Guid("7a86f1ad-c5b8-49fd-920e-057a7c7ea42e"), new Guid("60a0c724-b255-43fe-88c2-4148385cd1a6"), new DateOnly(2034, 7, 7), "/image/no_image.jpg", "Flute coursebook", 10.00m },
                    { new Guid("ac6e201e-a4d1-402e-bd2b-0389c802c6ad"), new Guid("59aa8dfe-04e7-4a4b-8618-10c003c69824"), new DateOnly(2023, 12, 20), "/image/no_image.jpg", "Chocolate bar", 2.34m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
