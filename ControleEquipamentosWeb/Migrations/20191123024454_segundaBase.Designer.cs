﻿// <auto-generated />
using System;
using ControleEquipamentosWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleEquipamentosWeb.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20191123024454_segundaBase")]
    partial class segundaBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControleEquipamentosWeb.Models.Emprestimo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataDevolucao");

                    b.Property<DateTime>("DataEmprestimo");

                    b.Property<DateTime>("DataPrevistaDevolucao");

                    b.Property<int?>("OperadorId");

                    b.Property<bool>("StatusEmprestimo");

                    b.Property<int?>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("OperadorId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Emprestimos");
                });

            modelBuilder.Entity("ControleEquipamentosWeb.Models.Equipamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Contador");

                    b.Property<DateTime>("CriadoEm");

                    b.Property<string>("Descricao");

                    b.Property<int?>("EmprestimoId");

                    b.Property<bool>("Inativo");

                    b.Property<string>("Marca");

                    b.Property<string>("Modelo");

                    b.Property<int>("NumeroRegistro");

                    b.Property<int?>("OperadorId");

                    b.HasKey("Id");

                    b.HasIndex("EmprestimoId");

                    b.HasIndex("OperadorId");

                    b.ToTable("Equipamentos");
                });

            modelBuilder.Entity("ControleEquipamentosWeb.Models.Ocorrencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataDevolucao");

                    b.Property<DateTime>("DataOcorrencia");

                    b.Property<string>("Descricao");

                    b.Property<int?>("EquipamentoId");

                    b.Property<int>("OrdemDeServico");

                    b.Property<DateTime>("PrevisaoRetorno");

                    b.HasKey("Id");

                    b.HasIndex("EquipamentoId");

                    b.ToTable("Ocorrencias");
                });

            modelBuilder.Entity("ControleEquipamentosWeb.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Admin");

                    b.Property<DateTime>("Aniversario");

                    b.Property<string>("CPF");

                    b.Property<DateTime>("CriadoEm");

                    b.Property<string>("Nome")
                        .HasMaxLength(200);

                    b.Property<string>("Usuario");

                    b.HasKey("Id");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("ControleEquipamentosWeb.Models.Emprestimo", b =>
                {
                    b.HasOne("ControleEquipamentosWeb.Models.Pessoa", "Operador")
                        .WithMany()
                        .HasForeignKey("OperadorId");

                    b.HasOne("ControleEquipamentosWeb.Models.Pessoa", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("ControleEquipamentosWeb.Models.Equipamento", b =>
                {
                    b.HasOne("ControleEquipamentosWeb.Models.Emprestimo")
                        .WithMany("Equipamentos")
                        .HasForeignKey("EmprestimoId");

                    b.HasOne("ControleEquipamentosWeb.Models.Pessoa", "Operador")
                        .WithMany()
                        .HasForeignKey("OperadorId");
                });

            modelBuilder.Entity("ControleEquipamentosWeb.Models.Ocorrencia", b =>
                {
                    b.HasOne("ControleEquipamentosWeb.Models.Equipamento", "Equipamento")
                        .WithMany()
                        .HasForeignKey("EquipamentoId");
                });
#pragma warning restore 612, 618
        }
    }
}