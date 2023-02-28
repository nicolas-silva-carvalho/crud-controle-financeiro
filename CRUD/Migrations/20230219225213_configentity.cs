using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD.Migrations
{
    /// <inheritdoc />
    public partial class configentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ControleFinanceiros_UsuariosId",
                table: "ControleFinanceiros");

            migrationBuilder.CreateIndex(
                name: "IX_ControleFinanceiros_UsuariosId",
                table: "ControleFinanceiros",
                column: "UsuariosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ControleFinanceiros_UsuariosId",
                table: "ControleFinanceiros");

            migrationBuilder.CreateIndex(
                name: "IX_ControleFinanceiros_UsuariosId",
                table: "ControleFinanceiros",
                column: "UsuariosId",
                unique: true);
        }
    }
}
