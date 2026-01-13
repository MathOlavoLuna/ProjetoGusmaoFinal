using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetoGusmaoFinal.Migrations
{
    /// <inheritdoc />
    public partial class RolesFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "Name", "RoleDescription" },
                values: new object[,]
                {
                    { 1, "MANAGER", "Pode adicionar livros PDF." },
                    { 2, "ALUNO", "Usuário comum" },
                    { 3, "SECRETÁRIO", "Pode criar nóticias e adicionar livros PDF." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
