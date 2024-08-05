using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitBox.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelWithComplexTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marmitas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TamanhoRecipiente = table.Column<int>(type: "int", nullable: false),
                    Carboidrato_Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carboidrato_Quantidade = table.Column<int>(type: "int", nullable: false),
                    Proteina_Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Proteina_Quantidade = table.Column<int>(type: "int", nullable: false),
                    Verdura = table.Column<bool>(type: "bit", nullable: false),
                    StatusDeConsumo = table.Column<bool>(type: "bit", nullable: false),
                    DataDoConsumo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Favorita = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marmitas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    Nome = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ReceitasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.Nome);
                    table.ForeignKey(
                        name: "FK_Ingredientes_Receitas_ReceitasId",
                        column: x => x.ReceitasId,
                        principalTable: "Receitas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_Nome",
                table: "Ingredientes",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_ReceitasId",
                table: "Ingredientes",
                column: "ReceitasId");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_Nome",
                table: "Receitas",
                column: "Nome",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Marmitas");

            migrationBuilder.DropTable(
                name: "Receitas");
        }
    }
}
