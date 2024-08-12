using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaDeGestao.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VendasModel>()
                .HasIndex(u => u.ProtocoloVenda)
                .IsUnique();
        }

    }
}
