using Microsoft.EntityFrameworkCore;
using SistemaDeGestao.Models;
namespace SistemaDeGestao.Data
{
    public class BancoContext : DbContext
    {
        public DbSet<FabricantesModel> Fabricantes { get; set; }
        public DbSet<VeiculosModel> Veiculos { get; set; }
        public DbSet<ConcessionariasModel> Concessionarias { get; set; }
        public DbSet<VendasModel> Vendas { get; set; }
    }
}
