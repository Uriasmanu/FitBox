using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitBox.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Receitas_ReceitasId",
                table: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Receitas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredientes",
                table: "Ingredientes");

            migrationBuilder.DropIndex(
                name: "IX_Ingredientes_Nome",
                table: "Ingredientes");

            migrationBuilder.DropIndex(
                name: "IX_Ingredientes_ReceitasId",
                table: "Ingredientes");

            migrationBuilder.DropColumn(
                name: "Carboidrato_Quantidade",
                table: "Marmitas");

            migrationBuilder.DropColumn(
                name: "Carboidrato_Tipo",
                table: "Marmitas");

            migrationBuilder.DropColumn(
                name: "Proteina_Quantidade",
                table: "Marmitas");

            migrationBuilder.DropColumn(
                name: "Proteina_Tipo",
                table: "Marmitas");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Ingredientes");

            migrationBuilder.DropColumn(
                name: "ReceitasId",
                table: "Ingredientes");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Ingredientes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Ingredientes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredientes",
                table: "Ingredientes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MarmitasIngredientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MarmitaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarmitasIngredientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarmitasIngredientes_Ingredientes_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarmitasIngredientes_Marmitas_MarmitaId",
                        column: x => x.MarmitaId,
                        principalTable: "Marmitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarmitasIngredientes_IngredienteId",
                table: "MarmitasIngredientes",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_MarmitasIngredientes_MarmitaId",
                table: "MarmitasIngredientes",
                column: "MarmitaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarmitasIngredientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredientes",
                table: "Ingredientes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Ingredientes");

            migrationBuilder.AddColumn<int>(
                name: "Carboidrato_Quantidade",
                table: "Marmitas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Carboidrato_Tipo",
                table: "Marmitas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Proteina_Quantidade",
                table: "Marmitas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Proteina_Tipo",
                table: "Marmitas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Ingredientes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Ingredientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReceitasId",
                table: "Ingredientes",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredientes",
                table: "Ingredientes",
                column: "Nome");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_Receitas_ReceitasId",
                table: "Ingredientes",
                column: "ReceitasId",
                principalTable: "Receitas",
                principalColumn: "Id");
        }
    }
}
