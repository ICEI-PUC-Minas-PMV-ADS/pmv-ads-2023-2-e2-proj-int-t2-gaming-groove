using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingGroove.Migrations
{
    /// <inheritdoc />
    public partial class M011 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_Comunidades_comunidadeId",
                table: "Denuncias");

            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_Publicacoes_publicacaoId",
                table: "Denuncias");

            migrationBuilder.AlterColumn<int>(
                name: "situacaoDenuncia",
                table: "Denuncias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "publicacaoId",
                table: "Denuncias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "denunciadoId",
                table: "Denuncias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "comunidadeId",
                table: "Denuncias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TipoDenuncia",
                table: "Denuncias",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Denuncias_Comunidades_comunidadeId",
                table: "Denuncias",
                column: "comunidadeId",
                principalTable: "Comunidades",
                principalColumn: "comunidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Denuncias_Publicacoes_publicacaoId",
                table: "Denuncias",
                column: "publicacaoId",
                principalTable: "Publicacoes",
                principalColumn: "publicacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_Comunidades_comunidadeId",
                table: "Denuncias");

            migrationBuilder.DropForeignKey(
                name: "FK_Denuncias_Publicacoes_publicacaoId",
                table: "Denuncias");

            migrationBuilder.DropColumn(
                name: "TipoDenuncia",
                table: "Denuncias");

            migrationBuilder.AlterColumn<int>(
                name: "situacaoDenuncia",
                table: "Denuncias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "publicacaoId",
                table: "Denuncias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "denunciadoId",
                table: "Denuncias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "comunidadeId",
                table: "Denuncias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
        }
    }
}
