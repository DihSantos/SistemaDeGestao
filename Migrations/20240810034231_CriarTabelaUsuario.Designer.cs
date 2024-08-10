﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaDeGestao.Data;

#nullable disable

namespace SistemaDeGestao.Migrations
{
    [DbContext(typeof(BancoContent))]
    [Migration("20240810034231_CriarTabelaUsuario")]
    partial class CriarTabelaUsuario
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemaDeGestao.Models.ConcessionariasModel", b =>
                {
                    b.Property<string>("Concessionaria")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("char(9)");

                    b.Property<int>("CapacidadeVeiculos")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("char(2)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Concessionaria");

                    b.ToTable("Concessionarias");
                });

            modelBuilder.Entity("SistemaDeGestao.Models.FabricantesModel", b =>
                {
                    b.Property<string>("Fabricante")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("AnoFundacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PaisOrigem")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Fabricante");

                    b.ToTable("Fabricantes");
                });

            modelBuilder.Entity("SistemaDeGestao.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SistemaDeGestao.Models.VeiculosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnoFabricacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Fabricante")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("Preco")
                        .HasColumnType("real");

                    b.Property<string>("TipoVeiculo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Fabricante");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("SistemaDeGestao.Models.VendasModel", b =>
                {
                    b.Property<int>("ProtocoloVenda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProtocoloVenda"));

                    b.Property<string>("ClienteCPF")
                        .IsRequired()
                        .HasColumnType("char(14)");

                    b.Property<string>("Concessionaria")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("DataVenda")
                        .HasColumnType("datetime2");

                    b.Property<string>("FoneCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PrecoVenda")
                        .HasColumnType("real");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("int");

                    b.Property<string>("VeiculoModelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProtocoloVenda");

                    b.HasIndex("Concessionaria");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("SistemaDeGestao.Models.VeiculosModel", b =>
                {
                    b.HasOne("SistemaDeGestao.Models.FabricantesModel", "Fabricantes")
                        .WithMany("Veiculos")
                        .HasForeignKey("Fabricante");

                    b.Navigation("Fabricantes");
                });

            modelBuilder.Entity("SistemaDeGestao.Models.VendasModel", b =>
                {
                    b.HasOne("SistemaDeGestao.Models.ConcessionariasModel", "Concessionarias")
                        .WithMany("Vendas")
                        .HasForeignKey("Concessionaria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaDeGestao.Models.VeiculosModel", "Veiculos")
                        .WithMany("Vendas")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concessionarias");

                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("SistemaDeGestao.Models.ConcessionariasModel", b =>
                {
                    b.Navigation("Vendas");
                });

            modelBuilder.Entity("SistemaDeGestao.Models.FabricantesModel", b =>
                {
                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("SistemaDeGestao.Models.VeiculosModel", b =>
                {
                    b.Navigation("Vendas");
                });
#pragma warning restore 612, 618
        }
    }
}
