using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoGusmaoFinal.Migrations
{
    /// <inheritdoc />
    public partial class fixrelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCategoriesBooks");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "BookCategories");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BookCategories");

            migrationBuilder.AddColumn<string>(
                name: "RoleDescription",
                table: "Roles",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "BookCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "BookCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategories_BookId",
                table: "BookCategories",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategories_CategoryId",
                table: "BookCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategories_Books_BookId",
                table: "BookCategories",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategories_Categories_CategoryId",
                table: "BookCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategories_Books_BookId",
                table: "BookCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCategories_Categories_CategoryId",
                table: "BookCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_BookCategories_BookId",
                table: "BookCategories");

            migrationBuilder.DropIndex(
                name: "IX_BookCategories_CategoryId",
                table: "BookCategories");

            migrationBuilder.DropColumn(
                name: "RoleDescription",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookCategories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "BookCategories");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BookCategories",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BookCategories",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BookCategoriesBooks",
                columns: table => new
                {
                    BookCategoriesId = table.Column<int>(type: "int", nullable: false),
                    BooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategoriesBooks", x => new { x.BookCategoriesId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_BookCategoriesBooks_BookCategories_BookCategoriesId",
                        column: x => x.BookCategoriesId,
                        principalTable: "BookCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategoriesBooks_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategoriesBooks_BooksId",
                table: "BookCategoriesBooks",
                column: "BooksId");
        }
    }
}
