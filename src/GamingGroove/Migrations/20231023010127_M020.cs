using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingGroove.Migrations
{
    /// <inheritdoc />
    public partial class M020 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuariosComunidades",
                columns: table => new
                {
                    usuarioId = table.Column<int>(type: "int", nullable: false),
                    comunidadeId = table.Column<int>(type: "int", nullable: false),
                    usuarioComunidadeId = table.Column<int>(type: "int", nullable: false),
                    cargoComunidade = table.Column<int>(type: "int", nullable: true),
                    dataVinculoComunidade = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosComunidades", x => new { x.usuarioId, x.comunidadeId });
                    table.ForeignKey(
                        name: "FK_UsuariosComunidades_Comunidades_comunidadeId",
                        column: x => x.comunidadeId,
                        principalTable: "Comunidades",
                        principalColumn: "comunidadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosComunidades_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuariosEquipes",
                columns: table => new
                {
                    usuarioId = table.Column<int>(type: "int", nullable: false),
                    equipeId = table.Column<int>(type: "int", nullable: false),
                    usuarioEquipeId = table.Column<int>(type: "int", nullable: false),
                    cargoEquipe = table.Column<int>(type: "int", nullable: true),
                    dataVinculoEquipe = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosEquipes", x => new { x.usuarioId, x.equipeId });
                    table.ForeignKey(
                        name: "FK_UsuariosEquipes_Equipes_equipeId",
                        column: x => x.equipeId,
                        principalTable: "Equipes",
                        principalColumn: "equipeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosEquipes_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosComunidades_comunidadeId",
                table: "UsuariosComunidades",
                column: "comunidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosEquipes_equipeId",
                table: "UsuariosEquipes",
                column: "equipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuariosComunidades");

            migrationBuilder.DropTable(
                name: "UsuariosEquipes");
        }
    }
}
