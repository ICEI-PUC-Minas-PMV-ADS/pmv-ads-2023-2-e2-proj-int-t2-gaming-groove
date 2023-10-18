using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingGroove.Migrations
{
    /// <inheritdoc />
    public partial class M018 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "jogosFavoritos",
                table: "Usuarios",
                newName: "terceiroJogo");

            migrationBuilder.AddColumn<int>(
                name: "primeiroJogo",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "segundoJogo",
                table: "Usuarios",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "primeiroJogo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "segundoJogo",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "terceiroJogo",
                table: "Usuarios",
                newName: "jogosFavoritos");
        }
    }
}
