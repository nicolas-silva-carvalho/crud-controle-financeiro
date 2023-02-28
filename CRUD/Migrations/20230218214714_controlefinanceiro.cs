using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD.Migrations
{
    /// <inheritdoc />
    public partial class controlefinanceiro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControleFinanceiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Produto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtdParcelas = table.Column<int>(type: "int", nullable: false),
                    Precototal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoPorParcela = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimoDiaParcela = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControleFinanceiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControleFinanceiros_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControleFinanceiros_UsuariosId",
                table: "ControleFinanceiros",
                column: "UsuariosId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControleFinanceiros");
        }
    }
}
