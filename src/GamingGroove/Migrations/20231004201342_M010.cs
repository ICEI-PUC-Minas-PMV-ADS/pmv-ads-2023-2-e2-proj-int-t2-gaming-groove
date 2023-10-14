using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingGroove.Migrations
{
    /// <inheritdoc />
    public partial class M010 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dataVinculoEquipe",
                table: "UsuarioEquipe",
                type: "datetime(6)",
                nullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "dataVinculoComunidade",
                table: "UsuarioComunidade",
                type: "datetime(6)",
                nullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "dataPublicacao",
                table: "Publicacoes",
                type: "datetime(6)",
                nullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "dataCriacaoEquipe",
                table: "Equipes",
                type: "datetime(6)",
                nullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "dataDenuncia",
                table: "Denuncias",
                type: "datetime(6)",
                nullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "dataCurtida",
                table: "Curtidas",
                type: "datetime(6)",
                nullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "dataCriacaoComunidade",
                table: "Comunidades",
                type: "datetime(6)",
                nullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "dataComentario",
                table: "Comentarios",
                type: "datetime(6)",
                nullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataChat",
                table: "Chats",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "dataAmizade",
                table: "Amizades",
                type: "datetime(6)",
                nullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataChat",
                table: "Chats",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }
    }
}
