using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingGroove.Migrations
{
    /// <inheritdoc />
    public partial class M019 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioComunidade");

            migrationBuilder.DropTable(
                name: "UsuarioEquipe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioComunidade",
                columns: table => new
                {
                    usuarioComunidadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    comunidadeId = table.Column<int>(type: "int", nullable: false),
                    usuarioId = table.Column<int>(type: "int", nullable: false),
                    cargo = table.Column<int>(type: "int", nullable: false),
                    dataVinculoComunidade = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioComunidade", x => x.usuarioComunidadeId);
                    table.ForeignKey(
                        name: "FK_UsuarioComunidade_Comunidades_comunidadeId",
                        column: x => x.comunidadeId,
                        principalTable: "Comunidades",
                        principalColumn: "comunidadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioComunidade_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuarioEquipe",
                columns: table => new
                {
                    usuarioEquipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    equipeId = table.Column<int>(type: "int", nullable: false),
                    usuarioId = table.Column<int>(type: "int", nullable: false),
                    cargoEquipe = table.Column<int>(type: "int", nullable: false),
                    dataVinculoEquipe = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEquipe", x => x.usuarioEquipeId);
                    table.ForeignKey(
                        name: "FK_UsuarioEquipe_Equipes_equipeId",
                        column: x => x.equipeId,
                        principalTable: "Equipes",
                        principalColumn: "equipeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioEquipe_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioComunidade_comunidadeId",
                table: "UsuarioComunidade",
                column: "comunidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioComunidade_usuarioId",
                table: "UsuarioComunidade",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEquipe_equipeId",
                table: "UsuarioEquipe",
                column: "equipeId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEquipe_usuarioId",
                table: "UsuarioEquipe",
                column: "usuarioId");
        }
    }
}
