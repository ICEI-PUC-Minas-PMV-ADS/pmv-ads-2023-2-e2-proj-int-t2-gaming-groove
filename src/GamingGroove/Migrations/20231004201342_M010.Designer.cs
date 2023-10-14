﻿// <auto-generated />
using System;
using GamingGroove.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GamingGroove.Migrations
{
    [DbContext(typeof(GamingGrooveDbContext))]
    [Migration("20231004201342_M010")]
    partial class M010
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GamingGroove.Models.AmizadeModel", b =>
                {
                    b.Property<int>("amizadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("dataAmizade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("estadoAmizade")
                        .HasColumnType("int");

                    b.Property<int>("receptorId")
                        .HasColumnType("int");

                    b.Property<int>("solicitanteId")
                        .HasColumnType("int");

                    b.HasKey("amizadeId");

                    b.HasIndex("receptorId");

                    b.HasIndex("solicitanteId");

                    b.ToTable("Amizades");
                });

            modelBuilder.Entity("GamingGroove.Models.ChatModel", b =>
                {
                    b.Property<int>("chatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("amizadeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("dataChat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<int>("equipeId")
                        .HasColumnType("int");

                    b.Property<string>("historico")
                        .HasColumnType("longtext");

                    b.HasKey("chatId");

                    b.HasIndex("amizadeId");

                    b.HasIndex("equipeId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("GamingGroove.Models.ComentarioModel", b =>
                {
                    b.Property<int>("comentarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("dataComentario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<byte[]>("midiaComentario")
                        .HasColumnType("longblob");

                    b.Property<int>("publicacaoId")
                        .HasColumnType("int");

                    b.Property<string>("textoComentario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("usuarioId")
                        .HasColumnType("int");

                    b.HasKey("comentarioId");

                    b.HasIndex("publicacaoId");

                    b.HasIndex("usuarioId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("GamingGroove.Models.ComunidadeModel", b =>
                {
                    b.Property<int>("comunidadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("capaComunidade")
                        .HasColumnType("longblob");

                    b.Property<DateTime?>("dataCriacaoComunidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("descricaoComunidade")
                        .HasColumnType("longtext");

                    b.Property<byte[]>("iconeComunidade")
                        .HasColumnType("longblob");

                    b.Property<int?>("jogosRelacionados")
                        .HasColumnType("int");

                    b.Property<string>("nomeComunidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("comunidadeId");

                    b.ToTable("Comunidades");
                });

            modelBuilder.Entity("GamingGroove.Models.CurtidaModel", b =>
                {
                    b.Property<int>("curtidaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("dataCurtida")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<int>("publicacaoId")
                        .HasColumnType("int");

                    b.Property<int>("usuarioId")
                        .HasColumnType("int");

                    b.HasKey("curtidaId");

                    b.HasIndex("publicacaoId");

                    b.HasIndex("usuarioId");

                    b.ToTable("Curtidas");
                });

            modelBuilder.Entity("GamingGroove.Models.DenunciaModel", b =>
                {
                    b.Property<int>("denunciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("comunidadeId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("dataDenuncia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("denunciadoId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("denuncianteId")
                        .HasColumnType("int");

                    b.Property<string>("descricaoDenuncia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("publicacaoId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("situacaoDenuncia")
                        .HasColumnType("int");

                    b.HasKey("denunciaId");

                    b.HasIndex("comunidadeId");

                    b.HasIndex("denunciadoId");

                    b.HasIndex("denuncianteId");

                    b.HasIndex("publicacaoId");

                    b.ToTable("Denuncias");
                });

            modelBuilder.Entity("GamingGroove.Models.EquipeModel", b =>
                {
                    b.Property<int>("equipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("dataCriacaoEquipe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("descricaoEquipe")
                        .HasColumnType("longtext");

                    b.Property<byte[]>("iconeEquipe")
                        .HasColumnType("longblob");

                    b.Property<int>("jogoEquipe")
                        .HasColumnType("int");

                    b.Property<string>("nomeEquipe")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("equipeId");

                    b.ToTable("Equipes");
                });

            modelBuilder.Entity("GamingGroove.Models.PublicacaoModel", b =>
                {
                    b.Property<int>("publicacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("comunidadeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("dataPublicacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<byte[]>("midiaPublicacao")
                        .HasColumnType("longblob");

                    b.Property<string>("textoPublicacao")
                        .HasColumnType("longtext");

                    b.Property<int>("usuarioId")
                        .HasColumnType("int");

                    b.HasKey("publicacaoId");

                    b.HasIndex("comunidadeId");

                    b.HasIndex("usuarioId");

                    b.ToTable("Publicacoes");
                });

            modelBuilder.Entity("GamingGroove.Models.UsuarioComunidadeModel", b =>
                {
                    b.Property<int>("usuarioComunidadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("cargo")
                        .HasColumnType("int");

                    b.Property<int>("comunidadeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("dataVinculoComunidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<int>("usuarioId")
                        .HasColumnType("int");

                    b.HasKey("usuarioComunidadeId");

                    b.HasIndex("comunidadeId");

                    b.HasIndex("usuarioId");

                    b.ToTable("UsuarioComunidade");
                });

            modelBuilder.Entity("GamingGroove.Models.UsuarioEquipeModel", b =>
                {
                    b.Property<int>("usuarioEquipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("cargoEquipe")
                        .HasColumnType("int");

                    b.Property<DateTime?>("dataVinculoEquipe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<int>("equipeId")
                        .HasColumnType("int");

                    b.Property<int>("usuarioId")
                        .HasColumnType("int");

                    b.HasKey("usuarioEquipeId");

                    b.HasIndex("equipeId");

                    b.HasIndex("usuarioId");

                    b.ToTable("UsuarioEquipe");
                });

            modelBuilder.Entity("GamingGroove.Models.UsuarioModel", b =>
                {
                    b.Property<int>("usuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("biografia")
                        .HasColumnType("longtext");

                    b.Property<byte[]>("capaPerfil")
                        .HasColumnType("longblob");

                    b.Property<DateTime>("dataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("fotosGaleria")
                        .HasColumnType("longblob");

                    b.Property<byte[]>("iconePerfil")
                        .HasColumnType("longblob");

                    b.Property<int?>("jogosFavoritos")
                        .HasColumnType("int");

                    b.Property<string>("nomeCompleto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nomeUsuario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("registrationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("tipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("usuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("GamingGroove.Models.AmizadeModel", b =>
                {
                    b.HasOne("GamingGroove.Models.UsuarioModel", "receptor")
                        .WithMany("receptorAmizade")
                        .HasForeignKey("receptorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GamingGroove.Models.UsuarioModel", "solicitante")
                        .WithMany("solicitanteAmizade")
                        .HasForeignKey("solicitanteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("receptor");

                    b.Navigation("solicitante");
                });

            modelBuilder.Entity("GamingGroove.Models.ChatModel", b =>
                {
                    b.HasOne("GamingGroove.Models.AmizadeModel", "amizade")
                        .WithMany("chatAmizade")
                        .HasForeignKey("amizadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroove.Models.EquipeModel", "equipe")
                        .WithMany("chatEquipe")
                        .HasForeignKey("equipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("amizade");

                    b.Navigation("equipe");
                });

            modelBuilder.Entity("GamingGroove.Models.ComentarioModel", b =>
                {
                    b.HasOne("GamingGroove.Models.PublicacaoModel", "publicacao")
                        .WithMany("publicacaoComentario")
                        .HasForeignKey("publicacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroove.Models.UsuarioModel", "usuario")
                        .WithMany("usuarioComentario")
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("publicacao");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("GamingGroove.Models.CurtidaModel", b =>
                {
                    b.HasOne("GamingGroove.Models.PublicacaoModel", "publicacao")
                        .WithMany("publicacaoCurtida")
                        .HasForeignKey("publicacaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GamingGroove.Models.UsuarioModel", "usuario")
                        .WithMany("usuarioCurtida")
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("publicacao");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("GamingGroove.Models.DenunciaModel", b =>
                {
                    b.HasOne("GamingGroove.Models.ComunidadeModel", "comunidade")
                        .WithMany("ComunidadeDenuncia")
                        .HasForeignKey("comunidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroove.Models.UsuarioModel", "denunciado")
                        .WithMany("denunciadoDenuncia")
                        .HasForeignKey("denunciadoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GamingGroove.Models.UsuarioModel", "denunciante")
                        .WithMany("denuncianteDenuncia")
                        .HasForeignKey("denuncianteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GamingGroove.Models.PublicacaoModel", "publicacao")
                        .WithMany("publicacaoDenuncia")
                        .HasForeignKey("publicacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("comunidade");

                    b.Navigation("denunciado");

                    b.Navigation("denunciante");

                    b.Navigation("publicacao");
                });

            modelBuilder.Entity("GamingGroove.Models.PublicacaoModel", b =>
                {
                    b.HasOne("GamingGroove.Models.ComunidadeModel", "comunidade")
                        .WithMany("ComunidadePublicacao")
                        .HasForeignKey("comunidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroove.Models.UsuarioModel", "usuario")
                        .WithMany("usuarioPublicacao")
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("comunidade");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("GamingGroove.Models.UsuarioComunidadeModel", b =>
                {
                    b.HasOne("GamingGroove.Models.ComunidadeModel", "comunidade")
                        .WithMany("usuarioComunidade")
                        .HasForeignKey("comunidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroove.Models.UsuarioModel", "usuario")
                        .WithMany("usuarioComunidade")
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("comunidade");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("GamingGroove.Models.UsuarioEquipeModel", b =>
                {
                    b.HasOne("GamingGroove.Models.EquipeModel", "equipe")
                        .WithMany("usuarioEquipe")
                        .HasForeignKey("equipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamingGroove.Models.UsuarioModel", "usuario")
                        .WithMany("usuarioEquipe")
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("equipe");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("GamingGroove.Models.AmizadeModel", b =>
                {
                    b.Navigation("chatAmizade");
                });

            modelBuilder.Entity("GamingGroove.Models.ComunidadeModel", b =>
                {
                    b.Navigation("ComunidadeDenuncia");

                    b.Navigation("ComunidadePublicacao");

                    b.Navigation("usuarioComunidade");
                });

            modelBuilder.Entity("GamingGroove.Models.EquipeModel", b =>
                {
                    b.Navigation("chatEquipe");

                    b.Navigation("usuarioEquipe");
                });

            modelBuilder.Entity("GamingGroove.Models.PublicacaoModel", b =>
                {
                    b.Navigation("publicacaoComentario");

                    b.Navigation("publicacaoCurtida");

                    b.Navigation("publicacaoDenuncia");
                });

            modelBuilder.Entity("GamingGroove.Models.UsuarioModel", b =>
                {
                    b.Navigation("denunciadoDenuncia");

                    b.Navigation("denuncianteDenuncia");

                    b.Navigation("receptorAmizade");

                    b.Navigation("solicitanteAmizade");

                    b.Navigation("usuarioComentario");

                    b.Navigation("usuarioComunidade");

                    b.Navigation("usuarioCurtida");

                    b.Navigation("usuarioEquipe");

                    b.Navigation("usuarioPublicacao");
                });
#pragma warning restore 612, 618
        }
    }
}
