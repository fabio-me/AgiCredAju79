using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgiCredAju79.Migrations
{
    /// <inheritdoc />
    public partial class emprestimo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emprestimo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CadastroId = table.Column<long>(type: "bigint", nullable: false),
                    CadastroResponsavelId = table.Column<long>(type: "bigint", nullable: true),
                    CadastroIndicacaoId = table.Column<long>(type: "bigint", nullable: true),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CPF = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CelularPrincipal = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Categoria = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoDeEmprestimo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorDoEmprestimo = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    JuroMensalPorcentagem = table.Column<int>(type: "int", nullable: true),
                    DataDoEmprestimo = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DiaDoPagamento = table.Column<int>(type: "int", nullable: true),
                    DataDoUltimoPagamento = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataDoAcordo = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataDePromessaDePagamento = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Observacao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emprestimo");
        }
    }
}
