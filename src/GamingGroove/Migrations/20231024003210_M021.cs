using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingGroove.Migrations
{
    /// <inheritdoc />
    public partial class M021 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "jogosRelacionados",
                table: "Comunidades",
                newName: "terceiroJogo");

            migrationBuilder.AddColumn<int>(
                name: "primeiroJogo",
                table: "Comunidades",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "segundoJogo",
                table: "Comunidades",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "primeiroJogo",
                table: "Comunidades");

            migrationBuilder.DropColumn(
                name: "segundoJogo",
                table: "Comunidades");

            migrationBuilder.RenameColumn(
                name: "terceiroJogo",
                table: "Comunidades",
                newName: "jogosRelacionados");
        }
    }
}
