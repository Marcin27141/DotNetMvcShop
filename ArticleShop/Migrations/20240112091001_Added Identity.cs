using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArticleShop.Migrations
{
    /// <inheritdoc />
    public partial class AddedIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
    }
}
