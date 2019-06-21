﻿// <auto-generated />
using System;
using GitProc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GitProc.Migrations.Migrations
{
    [DbContext(typeof(DomainDbContext))]
    [Migration("20190621062420_changeProcesso-1")]
    partial class changeProcesso1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("GitProc.Model.Data.Advogado", b =>
                {
                    b.Property<Guid>("AdvogadoId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid?>("EscritorioId");

                    b.Property<string>("Name");

                    b.Property<string>("OAB");

                    b.Property<Guid>("UsuarioId");

                    b.HasKey("AdvogadoId");

                    b.HasIndex("EscritorioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Advogados");
                });

            modelBuilder.Entity("GitProc.Model.Data.Arquivos", b =>
                {
                    b.Property<Guid>("ArquivosId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("ArquivosId");

                    b.ToTable("Arquivos");
                });

            modelBuilder.Entity("GitProc.Model.Data.Comentario", b =>
                {
                    b.Property<Guid>("ComentarioId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("ComentarioId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("GitProc.Model.Data.Escritorio", b =>
                {
                    b.Property<Guid>("EscritorioId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CNPJ");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Endereco");

                    b.Property<string>("Name");

                    b.HasKey("EscritorioId");

                    b.ToTable("Escritorios");
                });

            modelBuilder.Entity("GitProc.Model.Data.Movimento", b =>
                {
                    b.Property<Guid>("MovimentoId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<string>("Descricao");

                    b.Property<string>("Localizacao");

                    b.Property<Guid?>("ProcessoMasterId");

                    b.Property<string>("ProcessoNoTribunal");

                    b.Property<string>("TipoMovimento");

                    b.HasKey("MovimentoId");

                    b.HasIndex("ProcessoMasterId");

                    b.ToTable("Movimento");
                });

            modelBuilder.Entity("GitProc.Model.Data.Processo", b =>
                {
                    b.Property<Guid>("ProcessoId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AdvogadoId");

                    b.Property<string>("Comarca");

                    b.Property<DateTime>("DataAdicionado");

                    b.Property<Guid?>("EscritorioId");

                    b.Property<string>("Numero");

                    b.Property<Guid?>("ProcessoMasterId");

                    b.HasKey("ProcessoId");

                    b.HasIndex("AdvogadoId");

                    b.HasIndex("EscritorioId");

                    b.HasIndex("ProcessoMasterId");

                    b.ToTable("Processos");
                });

            modelBuilder.Entity("GitProc.Model.Data.ProcessoMaster", b =>
                {
                    b.Property<Guid>("ProcessoMasterId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Acao");

                    b.Property<string>("Advogados");

                    b.Property<string>("Assunto");

                    b.Property<string>("Bairro");

                    b.Property<string>("Cidade");

                    b.Property<string>("Classe");

                    b.Property<string>("Comarca");

                    b.Property<DateTime>("DataDistribuicao");

                    b.Property<DateTime>("DataVerificacao");

                    b.Property<string>("Endereco");

                    b.Property<string>("Instancia");

                    b.Property<string>("ProcessoId");

                    b.Property<string>("Tribunal");

                    b.Property<DateTime>("UpdatedDay");

                    b.HasKey("ProcessoMasterId");

                    b.ToTable("ProcessoMaster");
                });

            modelBuilder.Entity("GitProc.Model.Data.Usuario", b =>
                {
                    b.Property<Guid>("UsuarioId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastLogin");

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("GitProc.Model.Data.Advogado", b =>
                {
                    b.HasOne("GitProc.Model.Data.Escritorio", "Escritorio")
                        .WithMany()
                        .HasForeignKey("EscritorioId");

                    b.HasOne("GitProc.Model.Data.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GitProc.Model.Data.Movimento", b =>
                {
                    b.HasOne("GitProc.Model.Data.ProcessoMaster")
                        .WithMany("Movimentos")
                        .HasForeignKey("ProcessoMasterId");
                });

            modelBuilder.Entity("GitProc.Model.Data.Processo", b =>
                {
                    b.HasOne("GitProc.Model.Data.Advogado", "Advogado")
                        .WithMany()
                        .HasForeignKey("AdvogadoId");

                    b.HasOne("GitProc.Model.Data.Escritorio", "Escritorio")
                        .WithMany()
                        .HasForeignKey("EscritorioId");

                    b.HasOne("GitProc.Model.Data.ProcessoMaster", "ProcessoMaster")
                        .WithMany()
                        .HasForeignKey("ProcessoMasterId");
                });
#pragma warning restore 612, 618
        }
    }
}
