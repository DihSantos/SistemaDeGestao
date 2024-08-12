using SistemaDeGestao.Data;
using SistemaDeGestao.Interface;
using SistemaDeGestao.Models;

namespace SistemaDeGestao.Repository
{
    public class VendasRepository : IVendasRepository
    {
        private readonly BancoContent _context;

        public VendasRepository(BancoContent bancoContext)
        {
            _context = bancoContext;
        }

        public VendasModel ListarPorId(int Id)
        {
            return _context.Vendas.FirstOrDefault(x => x.Id == Id);
        }

        public List<VendasModel> GetAll()
        {
            return _context.Vendas.ToList();
        }

        public VendasModel Registrar(VendasModel vendas)
        {
            vendas.ProtocoloVenda = $"{DateTime.Now:yyyyMMddHHmmss}{new Random().Next(10,9999)}";
            
            vendas.DataVenda = DateTime.Now;
            _context.Vendas.Add(vendas);
            _context.SaveChanges();
            return vendas;
        }

        public bool Deletar(int Id)
        {
            VendasModel vendasDB = ListarPorId(Id);

            if (vendasDB == null) throw new Exception("Houve um erro ao apagar a venda!");

            _context.Vendas.Remove(vendasDB);
            _context.SaveChanges();
            return true;
        }

    }
}
