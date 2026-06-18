using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CW21.Presentation.Migrations
{
    /// <inheritdoc />
    public partial class bib : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthYear = table.Column<int>(type: "int", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    PublishYear = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookTags_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookTags_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTags_BookId",
                table: "BookTags",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTags_TagId",
                table: "BookTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Publisher_Name",
                table: "Publisher",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_Name",
                table: "Tag",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookTags");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
