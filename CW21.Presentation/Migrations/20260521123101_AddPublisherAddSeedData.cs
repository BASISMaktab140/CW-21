using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CW21.Presentation.Migrations
{
    /// <inheritdoc />
    public partial class AddPublisherAddSeedData : Migration
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
                    Description = table.Column<string>(type: "nvarchar(400)", nullable: false)
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
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "BirthYear", "Country", "FullName" },
                values: new object[,]
                {
                    { 1, 1952, "USA", "Robert C. Martin" },
                    { 2, 1963, "UK", "Martin Fowler" },
                    { 3, 1961, "Switzerland", "Erich Gamma" },
                    { 4, 1964, "USA", "Andrew Hunt" },
                    { 5, 1956, "USA", "David Thomas" },
                    { 6, 1976, "UK", "Jon Skeet" },
                    { 7, 1972, "USA", "Scott Hanselman" },
                    { 8, 1962, "USA", "Steve McConnell" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Programming and software engineering books", "Programming" },
                    { 2, "Architecture and design books", "Software Architecture" },
                    { 3, "Clean coding practices", "Clean Code" },
                    { 4, "Design patterns and best practices", "Design Patterns" },
                    { 5, "DevOps and software delivery", "DevOps" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "City", "CreatedAt", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "New York", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prentice Hall", "111111111" },
                    { 2, "California", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "O'Reilly Media", "222222222" },
                    { 3, "Boston", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Addison-Wesley", "333333333" },
                    { 4, "Washington", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Microsoft Press", "444444444" },
                    { 5, "Birmingham", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Packt Publishing", "555555555" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedAt", "Price", "PublishYear", "PublisherId", "Stock", "Title" },
                values: new object[,]
                {
                    { 1, 1, 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 700m, 2008, 1, 0, "Clean Code" },
                    { 2, 1, 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 650m, 2017, 1, 0, "Clean Architecture" },
                    { 3, 2, 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 720m, 1999, 3, 0, "Refactoring" },
                    { 4, 2, 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 690m, 2002, 3, 0, "Patterns of Enterprise Application Architecture" },
                    { 5, 3, 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 750m, 1994, 3, 0, "Design Patterns" },
                    { 6, 4, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 680m, 1999, 2, 0, "The Pragmatic Programmer" },
                    { 7, 5, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 730m, 2019, 2, 0, "The Pragmatic Programmer 20th Anniversary" },
                    { 8, 6, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 710m, 2019, 4, 0, "C# in Depth" },
                    { 9, 7, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 690m, 2020, 4, 0, "ASP.NET Core in Action" },
                    { 10, 8, 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 760m, 2004, 3, 0, "Code Complete" }
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
                name: "IX_Publisher_Name",
                table: "Publisher",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
