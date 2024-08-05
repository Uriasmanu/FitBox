using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitBox.Migrations
{
    /// <inheritdoc />
    public partial class atualizacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarmitasIngredientes_Ingredientes_IngredienteId",
                table: "MarmitasIngredientes");

            migrationBuilder.DropForeignKey(
                name: "FK_MarmitasIngredientes_Marmitas_MarmitaId",
                table: "MarmitasIngredientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MarmitasIngredientes",
                table: "MarmitasIngredientes");

            migrationBuilder.DropColumn(
                name: "DataDeCriacao",
                table: "Marmitas");

            migrationBuilder.RenameTable(
                name: "MarmitasIngredientes",
                newName: "MarmitaIngrediente");

            migrationBuilder.RenameColumn(
                name: "StatusDeConsumo",
                table: "Marmitas",
                newName: "Consumo");

            migrationBuilder.RenameColumn(
                name: "DataDoConsumo",
                table: "Marmitas",
                newName: "DataCriacao");

            migrationBuilder.RenameIndex(
                name: "IX_MarmitasIngredientes_MarmitaId",
                table: "MarmitaIngrediente",
                newName: "IX_MarmitaIngrediente_MarmitaId");

            migrationBuilder.RenameIndex(
                name: "IX_MarmitasIngredientes_IngredienteId",
                table: "MarmitaIngrediente",
                newName: "IX_MarmitaIngrediente_IngredienteId");

            migrationBuilder.AlterColumn<double>(
                name: "TamanhoRecipiente",
                table: "Marmitas",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "CarboidratoId",
                table: "Marmitas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataConsumo",
                table: "Marmitas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProteinaId",
                table: "Marmitas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "Quantidade",
                table: "Ingredientes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Ingredientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Quantidade",
                table: "MarmitaIngrediente",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarmitaIngrediente",
                table: "MarmitaIngrediente",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Marmitas_CarboidratoId",
                table: "Marmitas",
                column: "CarboidratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Marmitas_ProteinaId",
                table: "Marmitas",
                column: "ProteinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarmitaIngrediente_Ingredientes_IngredienteId",
                table: "MarmitaIngrediente",
                column: "IngredienteId",
                principalTable: "Ingredientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MarmitaIngrediente_Marmitas_MarmitaId",
                table: "MarmitaIngrediente",
                column: "MarmitaId",
                principalTable: "Marmitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Marmitas_Ingredientes_CarboidratoId",
                table: "Marmitas",
                column: "CarboidratoId",
                principalTable: "Ingredientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Marmitas_Ingredientes_ProteinaId",
                table: "Marmitas",
                column: "ProteinaId",
                principalTable: "Ingredientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarmitaIngrediente_Ingredientes_IngredienteId",
                table: "MarmitaIngrediente");

            migrationBuilder.DropForeignKey(
                name: "FK_MarmitaIngrediente_Marmitas_MarmitaId",
                table: "MarmitaIngrediente");

            migrationBuilder.DropForeignKey(
                name: "FK_Marmitas_Ingredientes_CarboidratoId",
                table: "Marmitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Marmitas_Ingredientes_ProteinaId",
                table: "Marmitas");

            migrationBuilder.DropIndex(
                name: "IX_Marmitas_CarboidratoId",
                table: "Marmitas");

            migrationBuilder.DropIndex(
                name: "IX_Marmitas_ProteinaId",
                table: "Marmitas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MarmitaIngrediente",
                table: "MarmitaIngrediente");

            migrationBuilder.DropColumn(
                name: "CarboidratoId",
                table: "Marmitas");

            migrationBuilder.DropColumn(
                name: "DataConsumo",
                table: "Marmitas");

            migrationBuilder.DropColumn(
                name: "ProteinaId",
                table: "Marmitas");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Ingredientes");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Ingredientes");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "MarmitaIngrediente");

            migrationBuilder.RenameTable(
                name: "MarmitaIngrediente",
                newName: "MarmitasIngredientes");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Marmitas",
                newName: "DataDoConsumo");

            migrationBuilder.RenameColumn(
                name: "Consumo",
                table: "Marmitas",
                newName: "StatusDeConsumo");

            migrationBuilder.RenameIndex(
                name: "IX_MarmitaIngrediente_MarmitaId",
                table: "MarmitasIngredientes",
                newName: "IX_MarmitasIngredientes_MarmitaId");

            migrationBuilder.RenameIndex(
                name: "IX_MarmitaIngrediente_IngredienteId",
                table: "MarmitasIngredientes",
                newName: "IX_MarmitasIngredientes_IngredienteId");

            migrationBuilder.AlterColumn<int>(
                name: "TamanhoRecipiente",
                table: "Marmitas",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeCriacao",
                table: "Marmitas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarmitasIngredientes",
                table: "MarmitasIngredientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MarmitasIngredientes_Ingredientes_IngredienteId",
                table: "MarmitasIngredientes",
                column: "IngredienteId",
                principalTable: "Ingredientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MarmitasIngredientes_Marmitas_MarmitaId",
                table: "MarmitasIngredientes",
                column: "MarmitaId",
                principalTable: "Marmitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
