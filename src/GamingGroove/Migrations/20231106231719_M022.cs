using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingGroove.Migrations
{
    /// <inheritdoc />
    public partial class M022 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amizades_Usuarios_receptorId",
                table: "Amizades");

            migrationBuilder.DropForeignKey(
                name: "FK_Amizades_Usuarios_solicitanteId",
                table: "Amizades");

            migrationBuilder.DropForeignKey(
                name: "FK_Curtidas_Publicacoes_publicacaoId",
                table: "Curtidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Curtidas_Usuarios_usuarioId",
                table: "Curtidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_Usuarios_denunciadoId",
                table: "Denuncias");

            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_Usuarios_denuncianteId",
                table: "Denuncias");

            migrationBuilder.AddForeignKey(
                name: "FK_Amizades_Usuarios_receptorId",
                table: "Amizades",
                column: "receptorId",
                principalTable: "Usuarios",
                principalColumn: "usuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Amizades_Usuarios_solicitanteId",
                table: "Amizades",
                column: "solicitanteId",
                principalTable: "Usuarios",
                principalColumn: "usuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Curtidas_Publicacoes_publicacaoId",
                table: "Curtidas",
                column: "publicacaoId",
                principalTable: "Publicacoes",
                principalColumn: "publicacaoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Curtidas_Usuarios_usuarioId",
                table: "Curtidas",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "usuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Denuncias_Usuarios_denunciadoId",
                table: "Denuncias",
                column: "denunciadoId",
                principalTable: "Usuarios",
                principalColumn: "usuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Denuncias_Usuarios_denuncianteId",
                table: "Denuncias",
                column: "denuncianteId",
                principalTable: "Usuarios",
                principalColumn: "usuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amizades_Usuarios_receptorId",
                table: "Amizades");

            migrationBuilder.DropForeignKey(
                name: "FK_Amizades_Usuarios_solicitanteId",
                table: "Amizades");

            migrationBuilder.DropForeignKey(
                name: "FK_Curtidas_Publicacoes_publicacaoId",
                table: "Curtidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Curtidas_Usuarios_usuarioId",
                table: "Curtidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_Usuarios_denunciadoId",
                table: "Denuncias");

            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_Usuarios_denuncianteId",
                table: "Denuncias");

            migrationBuilder.AddForeignKey(
                name: "FK_Amizades_Usuarios_receptorId",
                table: "Amizades",
                column: "receptorId",
                principalTable: "Usuarios",
                principalColumn: "usuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Amizades_Usuarios_solicitanteId",
                table: "Amizades",
                column: "solicitanteId",
                principalTable: "Usuarios",
                principalColumn: "usuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Curtidas_Publicacoes_publicacaoId",
                table: "Curtidas",
                column: "publicacaoId",
                principalTable: "Publicacoes",
                principalColumn: "publicacaoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Curtidas_Usuarios_usuarioId",
                table: "Curtidas",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "usuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Denuncias_Usuarios_denunciadoId",
                table: "Denuncias",
                column: "denunciadoId",
                principalTable: "Usuarios",
                principalColumn: "usuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Denuncias_Usuarios_denuncianteId",
                table: "Denuncias",
                column: "denuncianteId",
                principalTable: "Usuarios",
                principalColumn: "usuarioId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
