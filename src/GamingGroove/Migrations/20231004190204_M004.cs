using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingGroove.Migrations
{
    /// <inheritdoc />
    public partial class M004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dataVinculoEquipe",
                table: "UsuarioEquipe");

            migrationBuilder.DropColumn(
                name: "dataVinculoComunidade",
                table: "UsuarioComunidade");

            migrationBuilder.DropColumn(
                name: "dataPublicacao",
                table: "Publicacoes");

            migrationBuilder.DropColumn(
                name: "dataCriacaoEquipe",
                table: "Equipes");

            migrationBuilder.DropColumn(
                name: "dataDenuncia",
                table: "Denuncias");

            migrationBuilder.DropColumn(
                name: "dataCurtida",
                table: "Curtidas");

            migrationBuilder.DropColumn(
                name: "dataCriacaoComunidade",
                table: "Comunidades");

            migrationBuilder.DropColumn(
                name: "dataComentario",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "dataAmizade",
                table: "Amizades");

            migrationBuilder.AlterColumn<int>(
                name: "jogosFavoritos",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "jogoEquipe",
                table: "Equipes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<byte[]>(
                name: "iconeEquipe",
                table: "Equipes",
                type: "longblob",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "longblob");

            migrationBuilder.AlterColumn<string>(
                name: "descricaoEquipe",
                table: "Equipes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "situacaoDenuncia",
                table: "Denuncias",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "jogosRelacionados",
                table: "Comunidades",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<byte[]>(
                name: "iconeComunidade",
                table: "Comunidades",
                type: "longblob",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "longblob");

            migrationBuilder.AlterColumn<string>(
                name: "descricaoComunidade",
                table: "Comunidades",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<byte[]>(
                name: "capaComunidade",
                table: "Comunidades",
                type: "longblob",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "longblob");

            migrationBuilder.AlterColumn<byte[]>(
                name: "midiaComentario",
                table: "Comentarios",
                type: "longblob",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "longblob");

            migrationBuilder.AlterColumn<string>(
                name: "historico",
                table: "Chats",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataChat",
                table: "Chats",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<int>(
                name: "estadoAmizade",
                table: "Amizades",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "jogosFavoritos",
                table: "Usuarios",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "dataVinculoEquipe",
                table: "UsuarioEquipe",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dataVinculoComunidade",
                table: "UsuarioComunidade",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dataPublicacao",
                table: "Publicacoes",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "jogoEquipe",
                table: "Equipes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<byte[]>(
                name: "iconeEquipe",
                table: "Equipes",
                type: "longblob",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Equipes",
                keyColumn: "descricaoEquipe",
                keyValue: null,
                column: "descricaoEquipe",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "descricaoEquipe",
                table: "Equipes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "dataCriacaoEquipe",
                table: "Equipes",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "situacaoDenuncia",
                table: "Denuncias",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "dataDenuncia",
                table: "Denuncias",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dataCurtida",
                table: "Curtidas",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Comunidades",
                keyColumn: "jogosRelacionados",
                keyValue: null,
                column: "jogosRelacionados",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "jogosRelacionados",
                table: "Comunidades",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<byte[]>(
                name: "iconeComunidade",
                table: "Comunidades",
                type: "longblob",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Comunidades",
                keyColumn: "descricaoComunidade",
                keyValue: null,
                column: "descricaoComunidade",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "descricaoComunidade",
                table: "Comunidades",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<byte[]>(
                name: "capaComunidade",
                table: "Comunidades",
                type: "longblob",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dataCriacaoComunidade",
                table: "Comunidades",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<byte[]>(
                name: "midiaComentario",
                table: "Comentarios",
                type: "longblob",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dataComentario",
                table: "Comentarios",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "historico",
                keyValue: null,
                column: "historico",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "historico",
                table: "Chats",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataChat",
                table: "Chats",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Amizades",
                keyColumn: "estadoAmizade",
                keyValue: null,
                column: "estadoAmizade",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "estadoAmizade",
                table: "Amizades",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "dataAmizade",
                table: "Amizades",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
