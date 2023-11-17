using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingGroove.Migrations
{
    /// <inheritdoc />
    public partial class M016 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "registrationDate",
                table: "Usuarios",
                newName: "dataRegistro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dataRegistro",
                table: "Usuarios",
                newName: "registrationDate");
        }
    }
}
