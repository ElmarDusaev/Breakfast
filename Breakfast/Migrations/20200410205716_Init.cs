using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Breakfast.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientToken = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Stars = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    IsHit = table.Column<bool>(nullable: false),
                    Image = table.Column<string>(maxLength: 550, nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "OrderHdrs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 150, nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longtitude = table.Column<double>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    ClientName = table.Column<string>(maxLength: 50, nullable: true),
                    Sum = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeliveryDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHdrs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHdrs_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Basket_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Basket_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDtls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    OrderHdrId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDtls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDtls_OrderHdrs_OrderHdrId",
                        column: x => x.OrderHdrId,
                        principalTable: "OrderHdrs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDtls_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5d9cd6d4-e917-4826-a284-de69a9b45674", 0, "7ad9a4b6-b6d2-4f05-b444-7e5aab25f6e8", "admin@admin.com", false, false, null, "admin@admin.com", null, "AQAAAAEAACcQAAAAEObGWqDM0Kjna1Igiq2rLrpjwwRTf5iHpYGBY/1xVvzGKCrMKjJRAZyk3BTgLwMIMA==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "#Завтраки" },
                    { 2, "#Десерты" },
                    { 3, "#Соки" },
                    { 4, "#Хлеб" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "ClientToken" },
                values: new object[,]
                {
                    { 1, "6be1f4fa-4c32-44ad-85e2-8c5387e0c0aa" },
                    { 2, "7961ff2b-16ee-4ff2-9395-65cb0c078985" },
                    { 3, "1856b198-d205-4b9d-84e6-7c3413c7bf7c" },
                    { 4, "82003d01-9924-43d7-b32b-afeb16bb8302" },
                    { 5, "8bba2fa4-073b-456a-90b9-be5876c72301" },
                    { 6, "4c8ada0c-23db-4342-9689-e8728ec37f00" },
                    { 7, "308a1201-c902-408a-9a51-42c9ed55a2b6" }
                });

            migrationBuilder.InsertData(
                table: "OrderHdrs",
                columns: new[] { "Id", "Address", "ClientId", "ClientName", "CreatedDate", "DeliveryDateTime", "Latitude", "Longtitude", "Phone", "Status", "Sum" },
                values: new object[,]
                {
                    { 1, "Школа Чародейства и Волшебства Хогвартс 1", 1, "Невилл Долгопупс", new DateTime(2020, 4, 10, 23, 57, 15, 820, DateTimeKind.Local).AddTicks(8026), new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 2, 120.0 },
                    { 15, "Школа Чародейства и Волшебства Хогвартс 1", 1, "Невилл Долгопупс", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7666), new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 1, 120.0 },
                    { 16, "Школа Чародейства и Волшебства Хогвартс 1", 1, "Невилл Долгопупс", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7666), new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 2, 120.0 },
                    { 2, "Школа Чародейства и Волшебства Хогвартс 2", 2, "Сириус Блек", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7213), new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 2, 120.0 },
                    { 9, "Школа Чародейства и Волшебства Хогвартс 2", 2, "Сириус Блек", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7645), new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 0, 120.0 },
                    { 17, "Школа Чародейства и Волшебства Хогвартс 2", 2, "Сириус Блек", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7670), new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 2, 120.0 },
                    { 27, "Школа Чародейства и Волшебства Хогвартс 2", 2, "Сириус Блек", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7700), new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 2, 120.0 },
                    { 3, "Школа Чародейства и Волшебства Хогвартс 3", 3, "Гермиона Грейнджер", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7491), new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 3, 120.0 },
                    { 10, "Школа Чародейства и Волшебства Хогвартс 3", 3, "Гермиона Грейнджер", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7649), new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 0, 120.0 },
                    { 18, "Школа Чародейства и Волшебства Хогвартс 3", 3, "Гермиона Грейнджер", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7675), new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 3, 120.0 },
                    { 19, "Школа Чародейства и Волшебства Хогвартс 3", 3, "Гермиона Грейнджер", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7675), new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 4, 120.0 },
                    { 4, "Школа Чародейства и Волшебства Хогвартс 4", 4, "Гарри Поттер", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7495), new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 1, 120.0 },
                    { 11, "Школа Чародейства и Волшебства Хогвартс 4", 4, "Гарри Поттер", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7649), new DateTime(2020, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 2, 120.0 },
                    { 8, "Школа Чародейства и Волшебства Хогвартс 1", 1, "Невилл Долгопупс", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7641), new DateTime(2020, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 0, 120.0 },
                    { 20, "Школа Чародейства и Волшебства Хогвартс 4", 4, "Гарри Поттер", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7679), new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 0, 120.0 },
                    { 5, "Школа Чародейства и Волшебства Хогвартс 5", 5, "Рональд Уизли", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7500), new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 4, 120.0 },
                    { 12, "Школа Чародейства и Волшебства Хогвартс 5", 5, "Рональд Уизли", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7653), new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 4, 120.0 },
                    { 21, "Школа Чародейства и Волшебства Хогвартс 5", 5, "Рональд Уизли", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7683), new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 2, 120.0 },
                    { 22, "Школа Чародейства и Волшебства Хогвартс 5", 5, "Рональд Уизли", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7688), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 2, 120.0 },
                    { 28, "Школа Чародейства и Волшебства Хогвартс 5", 5, "Рональд Уизли", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7705), new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 2, 120.0 },
                    { 29, "Школа Чародейства и Волшебства Хогвартс 5", 5, "Рональд Уизли", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7705), new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 2, 120.0 },
                    { 6, "Школа Чародейства и Волшебства Хогвартс 6", 6, "Игорь Николев", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7504), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 4, 120.0 },
                    { 13, "Школа Чародейства и Волшебства Хогвартс 6", 6, "Игорь Николев", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7658), new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 4, 120.0 },
                    { 7, "Школа Чародейства и Волшебства Хогвартс 7", 7, "Альбус Дамблдор", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7636), new DateTime(2020, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 0, 120.0 },
                    { 14, "Школа Чародейства и Волшебства Хогвартс 7", 7, "Альбус Дамблдор", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7662), new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 1, 120.0 },
                    { 23, "Школа Чародейства и Волшебства Хогвартс 7", 7, "Альбус Дамблдор", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7688), new DateTime(2020, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 2, 120.0 },
                    { 24, "Школа Чародейства и Волшебства Хогвартс 7", 7, "Альбус Дамблдор", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7692), new DateTime(2020, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 2, 120.0 },
                    { 30, "Школа Чародейства и Волшебства Хогвартс 4", 4, "Игорь Николев", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7709), new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 2, 120.0 },
                    { 25, "Школа Чародейства и Волшебства Хогвартс 7", 7, "Альбус Дамблдор", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7696), new DateTime(2020, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 2, 120.0 },
                    { 26, "Школа Чародейства и Волшебства Хогвартс 7", 7, "Альбус Дамблдор", new DateTime(2020, 4, 10, 23, 57, 15, 823, DateTimeKind.Local).AddTicks(7696), new DateTime(2020, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0, 16.0, "1234567890", 2, 120.0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "IsHit", "Name", "Price", "Stars", "Status" },
                values: new object[,]
                {
                    { 28, 4, null, "http://russian7.ru/wp-content/uploads/2013/03/63.jpg", false, "Московский боярский хлеб", 70.0, 4.5, 1 },
                    { 2, 1, null, "https://foodandmood.com.ua/i/70/97/05/709705/gallery/e6a40ddde8c4b09d1c72dcdaae662a96-quality_75Xresize_1Xallow_enlarge_0Xw_700Xh_700.jpg", false, "Яичница по‑французски", 100.0, 4.5999999999999996, 1 },
                    { 3, 1, null, "https://img1.liveinternet.ru/images/attach/d/0/143/161/143161575_6425626_zavtrak_za_20_min_1.jpg", false, "Яичница в помидоре", 110.0, 4.4000000000000004, 1 },
                    { 4, 1, null, "https://elisheva.ru/uploads/posts/2016-11/1478615735_nezhnyi-omlet-s-gribami-i-syrom.jpg", false, "Бульбяная яичница", 135.0, 4.2000000000000002, 1 },
                    { 5, 1, null, "https://moi-kulinar.ru/uploads/posts/2018-07/1530946713_yaichnitsa-v-pertse.jpg", false, "Яичница в перце", 125.0, 4.0999999999999996, 1 },
                    { 6, 1, null, "https://omj.ru/wp-content/uploads/2017/04/4a1fa458fea1c74302fb2bf21b661a81.jpg", false, "Яичница в помидорах", 220.0, 4.2000000000000002, 1 },
                    { 7, 1, null, "https://foodman.club/wp-content/uploads/2017/10/21-5.jpg", false, "Яичница по‑французски в хлебе", 185.0, 4.2999999999999998, 1 },
                    { 8, 1, null, "https://cs8.pikabu.ru/post_img/2017/04/05/4/1491367487164439680.png", false, "Яичница со сметаной", 200.0, 4.0999999999999996, 1 },
                    { 9, 1, null, "https://fannykitchen.com/image/ing/2299.jpg", false, "Яичница-глазунья", 185.0, 4.4000000000000004, 1 },
                    { 10, 1, null, "https://cdn.segodnya.ua/img/article/11299/45_main_new.1523463015.jpg", false, "Яичница-болтунья со шпинатом", 140.0, 4.5, 1 },
                    { 11, 1, null, "https://www.owoman.ru/assets/images/cook/boltunya_iz_yaic2.jpg", false, "Яичница-болтунья", 150.0, 4.7000000000000002, 1 },
                    { 12, 1, null, "https://imgtest.mir24.tv/uploaded/images/crops/2018/October/870x489_1x1_detail_crop_c2325328884af7e2fee9343cbbe83a13f13d6a347fd4b10a5b98255587d6845f.jpg", false, "Яичница с брынзой", 145.0, 4.7999999999999998, 1 },
                    { 13, 1, null, "https://foodmag.me/wp-content/uploads/2017/05/yaichnitsa-v-pertsah-1.jpg", false, "Взбитая яичница", 135.0, 4.9000000000000004, 1 },
                    { 29, 4, null, "http://russian7.ru/wp-content/uploads/2013/03/81.jpg", false, "Стародубский хлеб", 45.0, 4.5999999999999996, 1 },
                    { 14, 1, null, "https://foodmag.me/wp-content/uploads/2017/05/yaichnitsa-v-pertsah-1-650x450.jpg", false, "Яичница по‑баскски", 210.0, 4.2000000000000002, 1 },
                    { 16, 2, null, "https://www.koolinar.ru/all_image/recipes/144/144777/recipe_1b7d00e6-ae0c-4d14-b3ee-fa3af188873c_large.jpg", false, "Классический чизкейк", 250.0, 4.0999999999999996, 1 },
                    { 17, 2, null, "https://sovkusom.ru/wp-content/uploads/recepty/k/kak-prigotovit-smetannyi-tort-na-skovorode/thumb-840x440.jpg", false, "Сметанный торт", 250.0, 4.2000000000000002, 1 },
                    { 18, 2, null, "https://www.koolinar.ru/all_image/recipes/144/144903/recipe_3865e7be-2722-40a3-87a7-4634c5dfced4_large.jpg", false, "Шоколадные маффины", 250.0, 4.2999999999999998, 1 },
                    { 19, 3, null, "https://img03.rl0.ru/7ecccd2ce12010f05a4e3f36a6fbb120/c615x400i/news.rambler.ru/img/2019/01/12025238.761283.5915.jpeg", false, "Свежевыжатый гранатовый сок", 100.0, 4.7999999999999998, 1 },
                    { 20, 3, null, "https://polzavred-edi.ru/wp-content/uploads/2019/06/polza-i-vred-apelsinovogo-soka.jpg", false, "Свежевыжатый апельсиновый сок", 80.0, 4.7000000000000002, 1 },
                    { 21, 3, null, "https://www.inmoment.ru/img/health-body/grapes-juice1.jpg", false, "Свежевыжатый виноградный сок", 80.0, 4.7000000000000002, 1 },
                    { 22, 3, null, "https://cafesahara.ru/upload/iblock/7ed/7eddcb30773af9e076d4d6ae8bc6a96a.jpg", false, "Свежевыжатый ананасовый сок", 80.0, 4.7000000000000002, 1 },
                    { 23, 4, null, "http://russian7.ru/wp-content/uploads/2013/03/13.jpg", false, "Белый хлеб", 55.0, 4.0999999999999996, 1 },
                    { 24, 4, null, "http://russian7.ru/wp-content/uploads/2013/03/22.jpg", false, "Черный хлеб", 45.0, 4.2999999999999998, 1 },
                    { 25, 4, null, "http://russian7.ru/wp-content/uploads/2013/03/22.jpg", false, "Красносельский хлеб", 65.0, 4.2000000000000002, 1 },
                    { 26, 4, null, "http://russian7.ru/wp-content/uploads/2013/03/7_russkix_xlebov.jpg", false, "Заварной хлеб", 75.0, 4.2999999999999998, 1 },
                    { 27, 4, null, "http://russian7.ru/wp-content/uploads/2013/03/53.jpg", false, "Бородинский хлеб", 80.0, 4.4000000000000004, 1 },
                    { 15, 1, null, "https://media-cdn.tripadvisor.com/media/photo-s/08/9b/f2/3e/caption.jpg", false, "Яичница по‑кончаловски", 150.0, 4.2999999999999998, 1 },
                    { 1, 1, null, "https://i.ytimg.com/vi/s0L8hrM6dXw/maxresdefault.jpg", true, "Яичница в хлебе", 90.0, 4.9000000000000004, 1 }
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

            migrationBuilder.CreateIndex(
                name: "IX_Basket_ClientId",
                table: "Basket",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_ProductId",
                table: "Basket",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDtls_OrderHdrId",
                table: "OrderDtls",
                column: "OrderHdrId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDtls_ProductId",
                table: "OrderDtls",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHdrs_ClientId",
                table: "OrderHdrs",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

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
                name: "Basket");

            migrationBuilder.DropTable(
                name: "OrderDtls");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "OrderHdrs");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
