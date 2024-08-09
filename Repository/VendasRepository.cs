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

        public VendasModel ListarPorId(int id)
        {
            return _context.Vendas.FirstOrDefault(x => x.Id == id);
        }

        public List<VendasModel> GetAll()
        {
            return _context.Vendas.ToList();
        }

        public VendasModel Registrar(VendasModel vendas)
        {
            _context.Vendas.Add(vendas);
            _context.SaveChanges();
            return vendas;
        }

        public bool Deletar(int id)
        {
            VendasModel vendasDB = ListarPorId(id);

            if (vendasDB == null) throw new Exception("Houve um erro ao apagar a venda!");

            _context.Vendas.Remove(vendasDB);
            _context.SaveChanges();
            return true;
        }

    }
}
