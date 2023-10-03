using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingGroove.Migrations
{
    /// <inheritdoc />
    public partial class M002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amizades_Usuarios_receptor_usuarioID",
                table: "Amizades");

            migrationBuilder.DropForeignKey(
                name: "FK_Amizades_Usuarios_solicitante_usuarioID",
                table: "Amizades");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Amizades_amizadeID",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Equipes_equipeID",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Publicacoes_publicacaoID",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Usuarios_usuarioID",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Curtidas_Publicacoes_publicacaoID",
                table: "Curtidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Curtidas_Usuarios_usuarioID",
                table: "Curtidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_Comunidades_comunidadeID",
                table: "Denuncias");

            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_Publicacoes_publicacaoID",
                table: "Denuncias");

            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_Usuarios_denunciado_usuarioID",
                table: "Denuncias");

            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_Usuarios_denunciante_usuarioID",
                table: "Denuncias");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacoes_Comunidades_comunidadeID",
                table: "Publicacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacoes_Usuarios_usuarioID",
                table: "Publicacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosComunidades_Comunidades_comunidadeID",
                table: "UsuariosComunidades");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosComunidades_Usuarios_usuarioID",
                table: "UsuariosComunidades");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosEquipes_Equipes_equipeID",
                table: "UsuariosEquipes");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosEquipes_Usuarios_usuarioID",
                table: "UsuariosEquipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuariosEquipes",
                table: "UsuariosEquipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuariosComunidades",
                table: "UsuariosComunidades");

            migrationBuilder.RenameTable(
                name: "UsuariosEquipes",
                newName: "UsuarioEquipe");

            migrationBuilder.RenameTable(
                name: "UsuariosComunidades",
                newName: "UsuarioComunidade");

            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "Usuarios",
                newName: "registrationDate");

            migrationBuilder.RenameColumn(
                name: "usuarioID",
                table: "Usuarios",
                newName: "usuarioId");

            migrationBuilder.RenameColumn(
                name: "usuarioID",
                table: "Publicacoes",
                newName: "usuarioId");

            migrationBuilder.RenameColumn(
                name: "comunidadeID",
                table: "Publicacoes",
                newName: "comunidadeId");

            migrationBuilder.RenameColumn(
                name: "publicacaoID",
                table: "Publicacoes",
                newName: "publicacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Publicacoes_usuarioID",
                table: "Publicacoes",
                newName: "IX_Publicacoes_usuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Publicacoes_comunidadeID",
                table: "Publicacoes",
                newName: "IX_Publicacoes_comunidadeId");

            migrationBuilder.RenameColumn(
                name: "equipeID",
                table: "Equipes",
                newName: "equipeId");

            migrationBuilder.RenameColumn(
                name: "publicacaoID",
                table: "Denuncias",
                newName: "publicacaoId");

            migrationBuilder.RenameColumn(
                name: "comunidadeID",
                table: "Denuncias",
                newName: "comunidadeId");

            migrationBuilder.RenameColumn(
                name: "denunciaID",
                table: "Denuncias",
                newName: "denunciaId");

            migrationBuilder.RenameColumn(
                name: "denunciante_usuarioID",
                table: "Denuncias",
                newName: "denuncianteId");

            migrationBuilder.RenameColumn(
                name: "denunciado_usuarioID",
                table: "Denuncias",
                newName: "denunciadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Denuncias_publicacaoID",
                table: "Denuncias",
                newName: "IX_Denuncias_publicacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Denuncias_comunidadeID",
                table: "Denuncias",
                newName: "IX_Denuncias_comunidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Denuncias_denunciante_usuarioID",
                table: "Denuncias",
                newName: "IX_Denuncias_denuncianteId");

            migrationBuilder.RenameIndex(
                name: "IX_Denuncias_denunciado_usuarioID",
                table: "Denuncias",
                newName: "IX_Denuncias_denunciadoId");

            migrationBuilder.RenameColumn(
                name: "usuarioID",
                table: "Curtidas",
                newName: "usuarioId");

            migrationBuilder.RenameColumn(
                name: "publicacaoID",
                table: "Curtidas",
                newName: "publicacaoId");

            migrationBuilder.RenameColumn(
                name: "curtidaID",
                table: "Curtidas",
                newName: "curtidaId");

            migrationBuilder.RenameIndex(
                name: "IX_Curtidas_usuarioID",
                table: "Curtidas",
                newName: "IX_Curtidas_usuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Curtidas_publicacaoID",
                table: "Curtidas",
                newName: "IX_Curtidas_publicacaoId");

            migrationBuilder.RenameColumn(
                name: "comunidadeID",
                table: "Comunidades",
                newName: "comunidadeId");

            migrationBuilder.RenameColumn(
                name: "usuarioID",
                table: "Comentarios",
                newName: "usuarioId");

            migrationBuilder.RenameColumn(
                name: "publicacaoID",
                table: "Comentarios",
                newName: "publicacaoId");

            migrationBuilder.RenameColumn(
                name: "comentarioID",
                table: "Comentarios",
                newName: "comentarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_usuarioID",
                table: "Comentarios",
                newName: "IX_Comentarios_usuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_publicacaoID",
                table: "Comentarios",
                newName: "IX_Comentarios_publicacaoId");

            migrationBuilder.RenameColumn(
                name: "equipeID",
                table: "Chats",
                newName: "equipeId");

            migrationBuilder.RenameColumn(
                name: "amizadeID",
                table: "Chats",
                newName: "amizadeId");

            migrationBuilder.RenameColumn(
                name: "chatID",
                table: "Chats",
                newName: "chatId");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_equipeID",
                table: "Chats",
                newName: "IX_Chats_equipeId");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_amizadeID",
                table: "Chats",
                newName: "IX_Chats_amizadeId");

            migrationBuilder.RenameColumn(
                name: "amizadeID",
                table: "Amizades",
                newName: "amizadeId");

            migrationBuilder.RenameColumn(
                name: "solicitante_usuarioID",
                table: "Amizades",
                newName: "solicitanteId");

            migrationBuilder.RenameColumn(
                name: "receptor_usuarioID",
                table: "Amizades",
                newName: "receptorId");

            migrationBuilder.RenameIndex(
                name: "IX_Amizades_solicitante_usuarioID",
                table: "Amizades",
                newName: "IX_Amizades_solicitanteId");

            migrationBuilder.RenameIndex(
                name: "IX_Amizades_receptor_usuarioID",
                table: "Amizades",
                newName: "IX_Amizades_receptorId");

            migrationBuilder.RenameColumn(
                name: "usuarioID",
                table: "UsuarioEquipe",
                newName: "usuarioId");

            migrationBuilder.RenameColumn(
                name: "equipeID",
                table: "UsuarioEquipe",
                newName: "equipeId");

            migrationBuilder.RenameColumn(
                name: "usuarioEquipeID",
                table: "UsuarioEquipe",
                newName: "usuarioEquipeId");

            migrationBuilder.RenameIndex(
                name: "IX_UsuariosEquipes_usuarioID",
                table: "UsuarioEquipe",
                newName: "IX_UsuarioEquipe_usuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_UsuariosEquipes_equipeID",
                table: "UsuarioEquipe",
                newName: "IX_UsuarioEquipe_equipeId");

            migrationBuilder.RenameColumn(
                name: "usuarioID",
                table: "UsuarioComunidade",
                newName: "usuarioId");

            migrationBuilder.RenameColumn(
                name: "comunidadeID",
                table: "UsuarioComunidade",
                newName: "comunidadeId");

            migrationBuilder.RenameColumn(
                name: "usuarioComunidadeID",
                table: "UsuarioComunidade",
                newName: "usuarioComunidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_UsuariosComunidades_usuarioID",
                table: "UsuarioComunidade",
                newName: "IX_UsuarioComunidade_usuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_UsuariosComunidades_comunidadeID",
                table: "UsuarioComunidade",
                newName: "IX_UsuarioComunidade_comunidadeId");

            migrationBuilder.AddColumn<int>(
                name: "tipoUsuario",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "cargoEquipe",
                table: "UsuarioEquipe",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "cargo",
                table: "UsuarioComunidade",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioEquipe",
                table: "UsuarioEquipe",
                column: "usuarioEquipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioComunidade",
                table: "UsuarioComunidade",
                column: "usuarioComunidadeId");

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
                name: "FK_Chats_Amizades_amizadeId",
                table: "Chats",
                column: "amizadeId",
                principalTable: "Amizades",
                principalColumn: "amizadeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Equipes_equipeId",
                table: "Chats",
                column: "equipeId",
                principalTable: "Equipes",
                principalColumn: "equipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Publicacoes_publicacaoId",
                table: "Comentarios",
                column: "publicacaoId",
                principalTable: "Publicacoes",
                principalColumn: "publicacaoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Usuarios_usuarioId",
                table: "Comentarios",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "usuarioId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Denuncias_Comunidades_comunidadeId",
                table: "Denuncias",
                column: "comunidadeId",
                principalTable: "Comunidades",
                principalColumn: "comunidadeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Denuncias_Publicacoes_publicacaoId",
                table: "Denuncias",
                column: "publicacaoId",
                principalTable: "Publicacoes",
                principalColumn: "publicacaoId",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacoes_Comunidades_comunidadeId",
                table: "Publicacoes",
                column: "comunidadeId",
                principalTable: "Comunidades",
                principalColumn: "comunidadeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacoes_Usuarios_usuarioId",
                table: "Publicacoes",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "usuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioComunidade_Comunidades_comunidadeId",
                table: "UsuarioComunidade",
                column: "comunidadeId",
                principalTable: "Comunidades",
                principalColumn: "comunidadeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioComunidade_Usuarios_usuarioId",
                table: "UsuarioComunidade",
                column: "usuarioId",
                principalTable: "Usuarios",
                principalColumn: "usuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioEquipe_Equipes_equipeId",
                table: "UsuarioEquipe",
                column: "equipeId",
                principalTable: "Equipes",
                principalColumn: "equipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioEquipe_Usuarios_usuarioId",
                table: "UsuarioEquipe",
                column: "usuarioId",
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
                name: "FK_Chats_Amizades_amizadeId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Equipes_equipeId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Publicacoes_publicacaoId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Usuarios_usuarioId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Curtidas_Publicacoes_publicacaoId",
                table: "Curtidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Curtidas_Usuarios_usuarioId",
                table: "Curtidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_Comunidades_comunidadeId",
                table: "Denuncias");

            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_Publicacoes_publicacaoId",
                table: "Denuncias");

            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_Usuarios_denunciadoId",
                table: "Denuncias");

            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_Usuarios_denuncianteId",
                table: "Denuncias");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacoes_Comunidades_comunidadeId",
                table: "Publicacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacoes_Usuarios_usuarioId",
                table: "Publicacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioComunidade_Comunidades_comunidadeId",
                table: "UsuarioComunidade");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioComunidade_Usuarios_usuarioId",
                table: "UsuarioComunidade");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioEquipe_Equipes_equipeId",
                table: "UsuarioEquipe");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioEquipe_Usuarios_usuarioId",
                table: "UsuarioEquipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioEquipe",
                table: "UsuarioEquipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioComunidade",
                table: "UsuarioComunidade");

            migrationBuilder.DropColumn(
                name: "tipoUsuario",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "UsuarioEquipe",
                newName: "UsuariosEquipes");

            migrationBuilder.RenameTable(
                name: "UsuarioComunidade",
                newName: "UsuariosComunidades");

            migrationBuilder.RenameColumn(
                name: "registrationDate",
                table: "Usuarios",
                newName: "RegistrationDate");

            migrationBuilder.RenameColumn(
                name: "usuarioId",
                table: "Usuarios",
                newName: "usuarioID");

            migrationBuilder.RenameColumn(
                name: "usuarioId",
                table: "Publicacoes",
                newName: "usuarioID");

            migrationBuilder.RenameColumn(
                name: "comunidadeId",
                table: "Publicacoes",
                newName: "comunidadeID");

            migrationBuilder.RenameColumn(
                name: "publicacaoId",
                table: "Publicacoes",
                newName: "publicacaoID");

            migrationBuilder.RenameIndex(
                name: "IX_Publicacoes_usuarioId",
                table: "Publicacoes",
                newName: "IX_Publicacoes_usuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Publicacoes_comunidadeId",
                table: "Publicacoes",
                newName: "IX_Publicacoes_comunidadeID");

            migrationBuilder.RenameColumn(
                name: "equipeId",
                table: "Equipes",
                newName: "equipeID");

            migrationBuilder.RenameColumn(
                name: "publicacaoId",
                table: "Denuncias",
                newName: "publicacaoID");

            migrationBuilder.RenameColumn(
                name: "comunidadeId",
                table: "Denuncias",
                newName: "comunidadeID");

            migrationBuilder.RenameColumn(
                name: "denunciaId",
                table: "Denuncias",
                newName: "denunciaID");

            migrationBuilder.RenameColumn(
                name: "denuncianteId",
                table: "Denuncias",
                newName: "denunciante_usuarioID");

            migrationBuilder.RenameColumn(
                name: "denunciadoId",
                table: "Denuncias",
                newName: "denunciado_usuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Denuncias_publicacaoId",
                table: "Denuncias",
                newName: "IX_Denuncias_publicacaoID");

            migrationBuilder.RenameIndex(
                name: "IX_Denuncias_comunidadeId",
                table: "Denuncias",
                newName: "IX_Denuncias_comunidadeID");

            migrationBuilder.RenameIndex(
                name: "IX_Denuncias_denuncianteId",
                table: "Denuncias",
                newName: "IX_Denuncias_denunciante_usuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Denuncias_denunciadoId",
                table: "Denuncias",
                newName: "IX_Denuncias_denunciado_usuarioID");

            migrationBuilder.RenameColumn(
                name: "usuarioId",
                table: "Curtidas",
                newName: "usuarioID");

            migrationBuilder.RenameColumn(
                name: "publicacaoId",
                table: "Curtidas",
                newName: "publicacaoID");

            migrationBuilder.RenameColumn(
                name: "curtidaId",
                table: "Curtidas",
                newName: "curtidaID");

            migrationBuilder.RenameIndex(
                name: "IX_Curtidas_usuarioId",
                table: "Curtidas",
                newName: "IX_Curtidas_usuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Curtidas_publicacaoId",
                table: "Curtidas",
                newName: "IX_Curtidas_publicacaoID");

            migrationBuilder.RenameColumn(
                name: "comunidadeId",
                table: "Comunidades",
                newName: "comunidadeID");

            migrationBuilder.RenameColumn(
                name: "usuarioId",
                table: "Comentarios",
                newName: "usuarioID");

            migrationBuilder.RenameColumn(
                name: "publicacaoId",
                table: "Comentarios",
                newName: "publicacaoID");

            migrationBuilder.RenameColumn(
                name: "comentarioId",
                table: "Comentarios",
                newName: "comentarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_usuarioId",
                table: "Comentarios",
                newName: "IX_Comentarios_usuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_publicacaoId",
                table: "Comentarios",
                newName: "IX_Comentarios_publicacaoID");

            migrationBuilder.RenameColumn(
                name: "equipeId",
                table: "Chats",
                newName: "equipeID");

            migrationBuilder.RenameColumn(
                name: "amizadeId",
                table: "Chats",
                newName: "amizadeID");

            migrationBuilder.RenameColumn(
                name: "chatId",
                table: "Chats",
                newName: "chatID");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_equipeId",
                table: "Chats",
                newName: "IX_Chats_equipeID");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_amizadeId",
                table: "Chats",
                newName: "IX_Chats_amizadeID");

            migrationBuilder.RenameColumn(
                name: "amizadeId",
                table: "Amizades",
                newName: "amizadeID");

            migrationBuilder.RenameColumn(
                name: "solicitanteId",
                table: "Amizades",
                newName: "solicitante_usuarioID");

            migrationBuilder.RenameColumn(
                name: "receptorId",
                table: "Amizades",
                newName: "receptor_usuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Amizades_solicitanteId",
                table: "Amizades",
                newName: "IX_Amizades_solicitante_usuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Amizades_receptorId",
                table: "Amizades",
                newName: "IX_Amizades_receptor_usuarioID");

            migrationBuilder.RenameColumn(
                name: "usuarioId",
                table: "UsuariosEquipes",
                newName: "usuarioID");

            migrationBuilder.RenameColumn(
                name: "equipeId",
                table: "UsuariosEquipes",
                newName: "equipeID");

            migrationBuilder.RenameColumn(
                name: "usuarioEquipeId",
                table: "UsuariosEquipes",
                newName: "usuarioEquipeID");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioEquipe_usuarioId",
                table: "UsuariosEquipes",
                newName: "IX_UsuariosEquipes_usuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioEquipe_equipeId",
                table: "UsuariosEquipes",
                newName: "IX_UsuariosEquipes_equipeID");

            migrationBuilder.RenameColumn(
                name: "usuarioId",
                table: "UsuariosComunidades",
                newName: "usuarioID");

            migrationBuilder.RenameColumn(
                name: "comunidadeId",
                table: "UsuariosComunidades",
                newName: "comunidadeID");

            migrationBuilder.RenameColumn(
                name: "usuarioComunidadeId",
                table: "UsuariosComunidades",
                newName: "usuarioComunidadeID");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioComunidade_usuarioId",
                table: "UsuariosComunidades",
                newName: "IX_UsuariosComunidades_usuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioComunidade_comunidadeId",
                table: "UsuariosComunidades",
                newName: "IX_UsuariosComunidades_comunidadeID");

            migrationBuilder.AlterColumn<string>(
                name: "cargoEquipe",
                table: "UsuariosEquipes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "cargo",
                table: "UsuariosComunidades",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuariosEquipes",
                table: "UsuariosEquipes",
                column: "usuarioEquipeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuariosComunidades",
                table: "UsuariosComunidades",
                column: "usuarioComunidadeID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Amizades_amizadeID",
                table: "Chats",
                column: "amizadeID",
                principalTable: "Amizades",
                principalColumn: "amizadeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Equipes_equipeID",
                table: "Chats",
                column: "equipeID",
                principalTable: "Equipes",
                principalColumn: "equipeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Publicacoes_publicacaoID",
                table: "Comentarios",
                column: "publicacaoID",
                principalTable: "Publicacoes",
                principalColumn: "publicacaoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Usuarios_usuarioID",
                table: "Comentarios",
                column: "usuarioID",
                principalTable: "Usuarios",
                principalColumn: "usuarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Curtidas_Publicacoes_publicacaoID",
                table: "Curtidas",
                column: "publicacaoID",
                principalTable: "Publicacoes",
                principalColumn: "publicacaoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Curtidas_Usuarios_usuarioID",
                table: "Curtidas",
                column: "usuarioID",
                principalTable: "Usuarios",
                principalColumn: "usuarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Denuncias_Comunidades_comunidadeID",
                table: "Denuncias",
                column: "comunidadeID",
                principalTable: "Comunidades",
                principalColumn: "comunidadeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Denuncias_Publicacoes_publicacaoID",
                table: "Denuncias",
                column: "publicacaoID",
                principalTable: "Publicacoes",
                principalColumn: "publicacaoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Denuncias_Usuarios_denunciado_usuarioID",
                table: "Denuncias",
                column: "denunciado_usuarioID",
                principalTable: "Usuarios",
                principalColumn: "usuarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Denuncias_Usuarios_denunciante_usuarioID",
                table: "Denuncias",
                column: "denunciante_usuarioID",
                principalTable: "Usuarios",
                principalColumn: "usuarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacoes_Comunidades_comunidadeID",
                table: "Publicacoes",
                column: "comunidadeID",
                principalTable: "Comunidades",
                principalColumn: "comunidadeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacoes_Usuarios_usuarioID",
                table: "Publicacoes",
                column: "usuarioID",
                principalTable: "Usuarios",
                principalColumn: "usuarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosComunidades_Comunidades_comunidadeID",
                table: "UsuariosComunidades",
                column: "comunidadeID",
                principalTable: "Comunidades",
                principalColumn: "comunidadeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosComunidades_Usuarios_usuarioID",
                table: "UsuariosComunidades",
                column: "usuarioID",
                principalTable: "Usuarios",
                principalColumn: "usuarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosEquipes_Equipes_equipeID",
                table: "UsuariosEquipes",
                column: "equipeID",
                principalTable: "Equipes",
                principalColumn: "equipeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosEquipes_Usuarios_usuarioID",
                table: "UsuariosEquipes",
                column: "usuarioID",
                principalTable: "Usuarios",
                principalColumn: "usuarioID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
