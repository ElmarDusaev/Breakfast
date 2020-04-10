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
                    Image = table.Column<string>(maxLength: 150, nullable: true),
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
                    CreatedDate = table.Column<DateTime>(nullable: false)
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
                values: new object[] { "2aa5d1b7-23ed-4f46-9bcf-bfbcc6037d40", 0, "3238298a-8824-4261-83d2-b05d3b1338f4", "admin@admin.com", false, false, null, "admin@admin.com", null, "AQAAAAEAACcQAAAAECh9hs6a97IDP2+QzQKnGUSWLaP5lHGcP6fohafedIW0d1lbq2B5WPcg9AVLUJqPnw==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Завтраки" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "IsHit", "Name", "Price", "Stars", "Status" },
                values: new object[,]
                {
                    { 1, 1, "Приготовить яичницу может любой человек, даже совершенно далекий от кулинарии. Сытно, просто, быстро и очень вкусно — именно так, коротко и ясно, можно охарактеризовать это блюдо. Чтобы сохранить желтки яиц целыми, достаточно просто аккуратно вылить яйцо на сковороду с маслом и поджарить их с одной или двух сторон. В зависимости от способа приготовления различают следующие виды яичницы-глазуньи: яичница-глазунья классическая; с беконом; яичница в форме сердца, цветка, солнца и т. д.; яйцо, поджаренное в хлебе; яичница, запеченная в помидорах, булочке или картофеле; яйцо в перце. И это не считая национальных блюд, которые готовят на разных кухнях мира. Способов приготовления яичницы, на самом деле, очень много. Все зависит от фантазии и финансовых возможностей самого человека.", "https://omj.ru/wp-content/uploads/2017/04/8ffa491e973b0c0fafc37397c73e633c.jpg", true, "Классическая глазунья", 300.0, 4.9000000000000004, 1 },
                    { 2, 1, "Полная противоположность глазунье — яичница-болтунья, при приготовлении которой яйца сначала взбивают с помощью вилки с солью, а затем уже обжаривают на сковороде со сливочным маслом. В зависимости от особенностей процесса приготовления бывают разные виды яичницы. Рецепты из приготовления заключаются в следующем: Яичница-болтунья по-английски. Для приготовления блюда 2 яйца взбивают вилкой со щепоткой соли и выливают на сковороду с разогретым сливочным маслом (20 г). В процессе жарки их постоянно перемешивают лопаткой, чтобы формировались слегка обжаренные комочки. Готовую яичницу рекомендуется подавать, выложив прямо на обжаренный тост. Яичница-болтунья по-французски. Для приготовления такого блюда 4 яйца взбивают венчиком с солью, а затем прямо в миске нагревают на водяной бане до готовности. Время приготовления такой яичницы составляет не менее 10 минут, при этом ее также необходимо перемешивать лопаткой для образования комочков. Общий принцип приготовления болтуньи — ни желтки, ни белки не должны оставаться целыми.", "https://omj.ru/wp-content/uploads/2017/04/0d04a1f18f9903f1da702c163e7553f5.jpg", false, "Яичница-болтунья", 850.0, 4.5999999999999996, 1 },
                    { 3, 1, "Одним из самых оригинальных и одновременно простых вариантов приготовления глазуньи является яичница с сосиской в форме сердца. И совсем необязательно ждать подходящего праздника, чтобы порадовать таким завтраком свою вторую половинку. Яичница с сосиской в виде сердца по времени готовится ничуть не дольше традиционной глазуньи с сосиской. При этом выглядит блюдо намного аппетитнее и интереснее. Сосиска разрезается вдоль таким способом, чтобы один край ее оставался непрорезанным. Разрезанная сосиска разделяется на две половинки, выворачивается в обратную сторону и выкладывается в форме сердца. Свободные края сосиски скрепляются зубочисткой. Налить на сковороду немного растительного масла, разогреть его и выложить сердечко из сосиски на сковороду. Немного обжарить сердечко с одной стороны, перевернуть на другую и разбить в центр яйцо. Добавить немного соли и перца по вкусу. Жарить яичницу до готовности, затем переложить на тарелку, украсить зеленью и тостами. Существуют и другие виды яичниц с сосиской, которые при подаче на стол выглядят также оригинально. Ниже рассмотрим пошаговое приготовление некоторых из них.", "https://omj.ru/wp-content/uploads/2017/04/d7d4038d7da2cfbf2589a034b4004501.jpg", false, "Яичница с сосиской в виде сердца", 1250.0, 4.4000000000000004, 1 },
                    { 4, 1, "Яйцо и сосиска — традиционное сочетание продуктов для приготовления яичницы. Но из этих двух ингредиентов можно легко сделать оригинальное блюдо. Яичница с сосиской в виде ромашки готовится в такой последовательности: Сосиска разрезается вдоль на 2 половинки. Затем на каждой части делаются надрезы, напоминающие бахрому. После этого обе половинки складываются в круг и скрепляются зубочистками. Из второй сосиски можно сделать еще пару цветов. Подготовленные сосиски выкладываются на сковороду с растительным маслом. В центр цветочка разбивается 1 яйцо. Желток яйца должен занять место серединки цветка. Как только яйца поджарятся их можно переложить на тарелку и украсить веточкой петрушки. Такая яичница с сосисками в виде цветочка станет отличным вариантом праздничного завтрака для женщины или ребенка. Приготовить ее совсем несложно и под силу каждому мужчине.", "https://omj.ru/wp-content/uploads/2017/04/785427770d9e097453e2db40cee911e4.jpg", false, "Цветочная тема в яичнице", 1550.0, 4.2000000000000002, 1 },
                    { 5, 1, "Очень аккуратно и аппетитно смотрится яичница, имеющая четко обозначенные края. Чтобы белок не растекался безобразно по сковороде, а принял определенную форму, используют специальные ограничители. Эту функцию могут выполнять специальные силиконовые формы, сосиски, скрепленные зубочисткой определенным способом, овощи (перец, лук) и хлеб. Таким образом, получаются новые и оригинальные виды яичниц. Аппетитную и вкусную яичницу на сковороде можно поджарить одновременно с хлебом, получив таким способом интересную закуску, завтрак или перекус. Яичница в виде сердца в хлебе готовится в такой последовательности: Белый или ржаной хлеб нарезается кусочками толщиной 1−1,5 см. Также можно использовать уже нарезанный хлеб для тостов. При помощи вырубки для печенья в мякише вырезается отверстие. Также можно воспользоваться обычным ножом, но края формы могут получиться не такими аккуратными. В сковороде разогревается немного сливочного и растительного масла. В центр сковороды выкладывается кусочек хлеба и обжаривается с одной стороны до румяной корочки. Затем хлеб переворачивается на другую сторону и в сделанное вырубкой отверстие разбивается яйцо. Добавляется соль и перец. Яйцо жарится на сковороде около 5 минут. После этого яичницу рекомендуется поместить в разогретую до 180° духовку на 5 минут, чтобы белок хорошо загустел. Вместо вырубки для печенья в виде сердца можно использовать и другую форму, например, круг, звездочку, цветок.", "https://omj.ru/wp-content/uploads/2017/04/4a1fa458fea1c74302fb2bf21b661a81.jpg", false, "Яичница в хлебе", 1850.0, 4.0999999999999996, 1 }
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
