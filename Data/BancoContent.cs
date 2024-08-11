﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaDeGestao.Models;
using System.Reflection.Metadata;
namespace SistemaDeGestao.Data
{
    public class BancoContent : IdentityDbContext
    {
        public BancoContent(DbContextOptions<BancoContent> options) : base(options)
        {

        }
        public DbSet<FabricantesModel> Fabricantes { get; set; }
        public DbSet<VeiculosModel> Veiculos { get; set; }
        public DbSet<ConcessionariasModel> Concessionarias { get; set; }
        public DbSet<VendasModel> Vendas { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VendasModel>()
                .HasIndex(u => u.ProtocoloVenda)
                .IsUnique();
        }

    }
}
