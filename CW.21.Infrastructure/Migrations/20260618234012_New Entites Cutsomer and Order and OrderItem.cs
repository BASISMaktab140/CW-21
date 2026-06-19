using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CW21.Presentation.Migrations
{
    /// <inheritdoc />
    public partial class NewEntitesCutsomerandOrderandOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTags_Tag_TagId",
                table: "BookTags");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "BookTags",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    OrderId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId1",
                        column: x => x.OrderId1,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_TagId",
                table: "Books",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Email",
                table: "Customer",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId1",
                table: "Order",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_BookId",
                table: "OrderItem",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId1",
                table: "OrderItem",
                column: "OrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Tags_TagId",
                table: "Books",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTags_Tags_TagId",
                table: "BookTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Tags_TagId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_BookTags_Tags_TagId",
                table: "BookTags");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Books_TagId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthYear", "Country", "FullName" },
                values: new object[,]
                {
                    { 1, null, "Romania", "Jon Skeet" },
                    { 2, null, "Germany", "Andrew Lock" },
                    { 3, null, "France", "Martin Fowler" },
                    { 4, null, "Italy", "Robert C. Martin" },
                    { 5, null, "Poland", "Julie Lerman" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Programming" },
                    { 2, null, "Database" },
                    { 3, null, "Backend" },
                    { 4, null, "Architecture" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "City", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, null, "Packt", null },
                    { 2, null, "O'Reilly", null },
                    { 3, null, "Manning", null },
                    { 4, null, "Apress", null }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedAt", "Price", "PublishYear", "PublisherId", "Stock", "Title" },
                values: new object[,]
                {
                    { 1, 5, 2, new DateTime(2026, 5, 29, 11, 37, 5, 769, DateTimeKind.Utc).AddTicks(5931), 299.99m, 2024, 4, 50, "EF Core Guide" },
                    { 2, 2, 3, new DateTime(2026, 5, 29, 11, 37, 5, 770, DateTimeKind.Utc).AddTicks(1577), 199.99m, 2023, 2, 35, "ASP.NET Core Basics" },
                    { 3, 4, 1, new DateTime(2026, 5, 29, 11, 37, 5, 770, DateTimeKind.Utc).AddTicks(1586), 249.99m, 2008, 3, 40, "Clean Code" },
                    { 4, 3, 4, new DateTime(2026, 5, 29, 11, 37, 5, 770, DateTimeKind.Utc).AddTicks(1593), 279.99m, 2018, 1, 20, "Refactoring" },
                    { 5, 1, 1, new DateTime(2026, 5, 29, 11, 37, 5, 770, DateTimeKind.Utc).AddTicks(1654), 320.00m, 2019, 3, 45, "C# in Depth" },
                    { 6, 5, 2, new DateTime(2026, 5, 29, 11, 37, 5, 770, DateTimeKind.Utc).AddTicks(1670), 180.50m, 2022, 4, 28, "SQL Server Essentials" },
                    { 7, 5, 2, new DateTime(2026, 5, 29, 11, 37, 5, 770, DateTimeKind.Utc).AddTicks(1676), 310.75m, 2021, 2, 18, "Entity Framework Mastery" },
                    { 8, 2, 3, new DateTime(2026, 5, 29, 11, 37, 5, 770, DateTimeKind.Utc).AddTicks(1683), 270.00m, 2020, 1, 33, "Designing REST APIs" },
                    { 9, 3, 4, new DateTime(2026, 5, 29, 11, 37, 5, 770, DateTimeKind.Utc).AddTicks(1689), 350.00m, 2024, 3, 22, "Microservices Fundamentals" },
                    { 10, 1, 1, new DateTime(2026, 5, 29, 11, 37, 5, 770, DateTimeKind.Utc).AddTicks(1700), 210.25m, 2021, 2, 26, "LINQ Deep Dive" },
                    { 11, 1, 1, new DateTime(2026, 5, 29, 11, 37, 5, 770, DateTimeKind.Utc).AddTicks(1707), 330.00m, 2022, 1, 31, "Advanced C#" },
                    { 12, 3, 2, new DateTime(2026, 5, 29, 11, 37, 5, 770, DateTimeKind.Utc).AddTicks(1713), 240.99m, 2020, 4, 19, "NoSQL for Developers" },
                    { 13, 2, 3, new DateTime(2026, 5, 29, 11, 37, 5, 770, DateTimeKind.Utc).AddTicks(1719), 289.99m, 2023, 3, 37, "Backend Development with .NET" },
                    { 14, 5, 2, new DateTime(2026, 5, 29, 11, 37, 5, 770, DateTimeKind.Utc).AddTicks(1726), 260.00m, 2019, 1, 24, "Database Design Principles" },
                    { 15, 4, 4, new DateTime(2026, 5, 29, 11, 37, 5, 770, DateTimeKind.Utc).AddTicks(1733), 295.00m, 2017, 2, 29, "Clean Architecture" },
                    { 16, 2, 3, new DateTime(2026, 5, 29, 11, 37, 5, 770, DateTimeKind.Utc).AddTicks(1739), 205.50m, 2021, 4, 17, "Practical Dependency Injection" },
                    { 17, 3, 2, new DateTime(2026, 5, 29, 11, 37, 5, 770, DateTimeKind.Utc).AddTicks(1745), 275.75m, 2022, 2, 21, "Mastering PostgreSQL" },
                    { 18, 4, 4, new DateTime(2026, 5, 29, 11, 37, 5, 770, DateTimeKind.Utc).AddTicks(1755), 315.25m, 2020, 3, 27, "Software Engineering Patterns" },
                    { 19, 2, 3, new DateTime(2026, 5, 29, 11, 37, 5, 770, DateTimeKind.Utc).AddTicks(1761), 285.40m, 2024, 1, 32, "Building APIs with ASP.NET Core" },
                    { 20, 5, 2, new DateTime(2026, 5, 29, 11, 37, 5, 770, DateTimeKind.Utc).AddTicks(1768), 230.00m, 2023, 4, 23, "Data Access in .NET" }
                });

            migrationBuilder.InsertData(
                table: "BookTags",
                columns: new[] { "Id", "BookId", "TagId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 2, 1 },
                    { 5, 2, 3 },
                    { 6, 3, 1 },
                    { 7, 3, 5 },
                    { 8, 4, 4 },
                    { 9, 4, 1 },
                    { 10, 5, 1 },
                    { 11, 6, 2 },
                    { 12, 7, 2 },
                    { 13, 7, 3 },
                    { 14, 7, 1 },
                    { 15, 8, 3 },
                    { 16, 8, 4 },
                    { 17, 9, 3 },
                    { 18, 9, 4 },
                    { 19, 10, 1 },
                    { 20, 11, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tag_Name",
                table: "Tag",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookTags_Tag_TagId",
                table: "BookTags",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
