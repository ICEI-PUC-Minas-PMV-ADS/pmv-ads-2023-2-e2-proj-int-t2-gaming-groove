using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingGroove.Migrations
{
    /// <inheritdoc />
    public partial class Migracao001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amizades_Usuarios_receptorusuarioID",
                table: "Amizades");

            migrationBuilder.DropForeignKey(
                name: "FK_Amizades_Usuarios_solicitanteusuarioID",
                table: "Amizades");

            migrationBuilder.RenameColumn(
                name: "solicitanteusuarioID",
                table: "Amizades",
                newName: "solicitante_usuarioID");

            migrationBuilder.RenameColumn(
                name: "receptorusuarioID",
                table: "Amizades",
                newName: "receptor_usuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Amizades_solicitanteusuarioID",
                table: "Amizades",
                newName: "IX_Amizades_solicitante_usuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Amizades_receptorusuarioID",
                table: "Amizades",
                newName: "IX_Amizades_receptor_usuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Amizades_Usuarios_receptor_usuarioID",
                table: "Amizades",
                column: "receptor_usuarioID",
                principalTable: "Usuarios",
                principalColumn: "usuarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Amizades_Usuarios_solicitante_usuarioID",
                table: "Amizades",
                column: "solicitante_usuarioID",
                principalTable: "Usuarios",
                principalColumn: "usuarioID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amizades_Usuarios_receptor_usuarioID",
                table: "Amizades");

            migrationBuilder.DropForeignKey(
                name: "FK_Amizades_Usuarios_solicitante_usuarioID",
                table: "Amizades");

            migrationBuilder.RenameColumn(
                name: "solicitante_usuarioID",
                table: "Amizades",
                newName: "solicitanteusuarioID");

            migrationBuilder.RenameColumn(
                name: "receptor_usuarioID",
                table: "Amizades",
                newName: "receptorusuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Amizades_solicitante_usuarioID",
                table: "Amizades",
                newName: "IX_Amizades_solicitanteusuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Amizades_receptor_usuarioID",
                table: "Amizades",
                newName: "IX_Amizades_receptorusuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Amizades_Usuarios_receptorusuarioID",
                table: "Amizades",
                column: "receptorusuarioID",
                principalTable: "Usuarios",
                principalColumn: "usuarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Amizades_Usuarios_solicitanteusuarioID",
                table: "Amizades",
                column: "solicitanteusuarioID",
                principalTable: "Usuarios",
                principalColumn: "usuarioID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
