using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitBox.Migrations
{
    /// <inheritdoc />
    public partial class AddFavoritaToMarmitas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Favorita",
                table: "Ingredientes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favorita",
                table: "Ingredientes");
        }
    }
}
