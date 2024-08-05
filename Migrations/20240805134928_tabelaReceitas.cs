using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitBox.Migrations
{
    /// <inheritdoc />
    public partial class tabelaReceitas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    TamanhoRecipiente = table.Column<int>(nullable: false),
                    ProteinaId = table.Column<Guid>(nullable: false),
                    CarboidratoId = table.Column<Guid>(nullable: false),
                    Verdura = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    Favorita = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receitas_Ingredientes_CarboidratoId",
                        column: x => x.CarboidratoId,
                        principalTable: "Ingredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction); // Atualizado aqui
                    table.ForeignKey(
                        name: "FK_Receitas_Ingredientes_ProteinaId",
                        column: x => x.ProteinaId,
                        principalTable: "Ingredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction); // Atualizado aqui
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_CarboidratoId",
                table: "Receitas",
                column: "CarboidratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_ProteinaId",
                table: "Receitas",
                column: "ProteinaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receitas");
        }
    }
}