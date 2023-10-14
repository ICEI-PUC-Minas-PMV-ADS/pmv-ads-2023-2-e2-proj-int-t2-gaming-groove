using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingGroove.Migrations
{
    /// <inheritdoc />
    public partial class M001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Comunidades",
                columns: table => new
                {
                    comunidadeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nomeComunidade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    iconeComunidade = table.Column<byte[]>(type: "longblob", nullable: false),
                    capaComunidade = table.Column<byte[]>(type: "longblob", nullable: false),
                    jogosRelacionados = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descricaoComunidade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dataCriacaoComunidade = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comunidades", x => x.comunidadeID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    equipeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nomeEquipe = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    iconeEquipe = table.Column<byte[]>(type: "longblob", nullable: false),
                    descricaoEquipe = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    jogoEquipe = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dataCriacaoEquipe = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.equipeID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    usuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nomeUsuario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nomeCompleto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    senha = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    iconePerfil = table.Column<byte[]>(type: "longblob", nullable: true),
                    capaPerfil = table.Column<byte[]>(type: "longblob", nullable: true),
                    fotosGaleria = table.Column<byte[]>(type: "longblob", nullable: true),
                    jogosFavoritos = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    biografia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegistrationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.usuarioID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Amizades",
                columns: table => new
                {
                    amizadeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    solicitante_usuarioID = table.Column<int>(type: "int", nullable: false),
                    receptor_usuarioID = table.Column<int>(type: "int", nullable: false),
                    estadoAmizade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dataAmizade = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amizades", x => x.amizadeID);
                    table.ForeignKey(
                        name: "FK_Amizades_Usuarios_receptor_usuarioID",
                        column: x => x.receptor_usuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Amizades_Usuarios_solicitante_usuarioID",
                        column: x => x.solicitante_usuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Publicacoes",
                columns: table => new
                {
                    publicacaoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    usuarioID = table.Column<int>(type: "int", nullable: false),
                    comunidadeID = table.Column<int>(type: "int", nullable: false),
                    textoPublicacao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    midiaPublicacao = table.Column<byte[]>(type: "longblob", nullable: true),
                    dataPublicacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicacoes", x => x.publicacaoID);
                    table.ForeignKey(
                        name: "FK_Publicacoes_Comunidades_comunidadeID",
                        column: x => x.comunidadeID,
                        principalTable: "Comunidades",
                        principalColumn: "comunidadeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publicacoes_Usuarios_usuarioID",
                        column: x => x.usuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuariosComunidades",
                columns: table => new
                {
                    usuarioComunidadeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    usuarioID = table.Column<int>(type: "int", nullable: false),
                    comunidadeID = table.Column<int>(type: "int", nullable: false),
                    cargo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dataVinculoComunidade = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosComunidades", x => x.usuarioComunidadeID);
                    table.ForeignKey(
                        name: "FK_UsuariosComunidades_Comunidades_comunidadeID",
                        column: x => x.comunidadeID,
                        principalTable: "Comunidades",
                        principalColumn: "comunidadeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosComunidades_Usuarios_usuarioID",
                        column: x => x.usuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuariosEquipes",
                columns: table => new
                {
                    usuarioEquipeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    usuarioID = table.Column<int>(type: "int", nullable: false),
                    equipeID = table.Column<int>(type: "int", nullable: false),
                    cargoEquipe = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dataVinculoEquipe = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosEquipes", x => x.usuarioEquipeID);
                    table.ForeignKey(
                        name: "FK_UsuariosEquipes_Equipes_equipeID",
                        column: x => x.equipeID,
                        principalTable: "Equipes",
                        principalColumn: "equipeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosEquipes_Usuarios_usuarioID",
                        column: x => x.usuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    chatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    equipeID = table.Column<int>(type: "int", nullable: false),
                    amizadeID = table.Column<int>(type: "int", nullable: false),
                    historico = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dataChat = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.chatID);
                    table.ForeignKey(
                        name: "FK_Chats_Amizades_amizadeID",
                        column: x => x.amizadeID,
                        principalTable: "Amizades",
                        principalColumn: "amizadeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chats_Equipes_equipeID",
                        column: x => x.equipeID,
                        principalTable: "Equipes",
                        principalColumn: "equipeID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    comentarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    usuarioID = table.Column<int>(type: "int", nullable: false),
                    publicacaoID = table.Column<int>(type: "int", nullable: false),
                    textoComentario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    midiaComentario = table.Column<byte[]>(type: "longblob", nullable: false),
                    dataComentario = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.comentarioID);
                    table.ForeignKey(
                        name: "FK_Comentarios_Publicacoes_publicacaoID",
                        column: x => x.publicacaoID,
                        principalTable: "Publicacoes",
                        principalColumn: "publicacaoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentarios_Usuarios_usuarioID",
                        column: x => x.usuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Curtidas",
                columns: table => new
                {
                    curtidaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    usuarioID = table.Column<int>(type: "int", nullable: false),
                    publicacaoID = table.Column<int>(type: "int", nullable: false),
                    dataCurtida = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curtidas", x => x.curtidaID);
                    table.ForeignKey(
                        name: "FK_Curtidas_Publicacoes_publicacaoID",
                        column: x => x.publicacaoID,
                        principalTable: "Publicacoes",
                        principalColumn: "publicacaoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Curtidas_Usuarios_usuarioID",
                        column: x => x.usuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Denuncias",
                columns: table => new
                {
                    denunciaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    denunciante_usuarioID = table.Column<int>(type: "int", nullable: false),
                    denunciado_usuarioID = table.Column<int>(type: "int", nullable: false),
                    publicacaoID = table.Column<int>(type: "int", nullable: false),
                    comunidadeID = table.Column<int>(type: "int", nullable: false),
                    descricaoDenuncia = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    situacaoDenuncia = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dataDenuncia = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denuncias", x => x.denunciaID);
                    table.ForeignKey(
                        name: "FK_Denuncias_Comunidades_comunidadeID",
                        column: x => x.comunidadeID,
                        principalTable: "Comunidades",
                        principalColumn: "comunidadeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Denuncias_Publicacoes_publicacaoID",
                        column: x => x.publicacaoID,
                        principalTable: "Publicacoes",
                        principalColumn: "publicacaoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Denuncias_Usuarios_denunciado_usuarioID",
                        column: x => x.denunciado_usuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Denuncias_Usuarios_denunciante_usuarioID",
                        column: x => x.denunciante_usuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Amizades_receptor_usuarioID",
                table: "Amizades",
                column: "receptor_usuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Amizades_solicitante_usuarioID",
                table: "Amizades",
                column: "solicitante_usuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_amizadeID",
                table: "Chats",
                column: "amizadeID");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_equipeID",
                table: "Chats",
                column: "equipeID");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_publicacaoID",
                table: "Comentarios",
                column: "publicacaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_usuarioID",
                table: "Comentarios",
                column: "usuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Curtidas_publicacaoID",
                table: "Curtidas",
                column: "publicacaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Curtidas_usuarioID",
                table: "Curtidas",
                column: "usuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_comunidadeID",
                table: "Denuncias",
                column: "comunidadeID");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_denunciado_usuarioID",
                table: "Denuncias",
                column: "denunciado_usuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_denunciante_usuarioID",
                table: "Denuncias",
                column: "denunciante_usuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Denuncias_publicacaoID",
                table: "Denuncias",
                column: "publicacaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacoes_comunidadeID",
                table: "Publicacoes",
                column: "comunidadeID");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacoes_usuarioID",
                table: "Publicacoes",
                column: "usuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosComunidades_comunidadeID",
                table: "UsuariosComunidades",
                column: "comunidadeID");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosComunidades_usuarioID",
                table: "UsuariosComunidades",
                column: "usuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosEquipes_equipeID",
                table: "UsuariosEquipes",
                column: "equipeID");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosEquipes_usuarioID",
                table: "UsuariosEquipes",
                column: "usuarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Curtidas");

            migrationBuilder.DropTable(
                name: "Denuncias");

            migrationBuilder.DropTable(
                name: "UsuariosComunidades");

            migrationBuilder.DropTable(
                name: "UsuariosEquipes");

            migrationBuilder.DropTable(
                name: "Amizades");

            migrationBuilder.DropTable(
                name: "Publicacoes");

            migrationBuilder.DropTable(
                name: "Equipes");

            migrationBuilder.DropTable(
                name: "Comunidades");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
