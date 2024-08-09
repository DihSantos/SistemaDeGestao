using GestaoDeVendas.Data;
using GestaoDeVendas.Interface;
using GestaoDeVendas.Models;

namespace GestaoDeVendas.Repository
{
    public class VendasRepository : IVendasRepository
    {
        private readonly BancoContext _bancoContext;

        public VendasRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public VendasModel ListarPorId(int id)
        {
            return _bancoContext.Vendas.FirstOrDefault(x => x.Id == id);
        }

        public List<VendasModel> GetAll()
        {
            return _bancoContext.Vendas.ToList();
        }

        public VendasModel Registrar(VendasModel vendas)
        {
            _bancoContext.Vendas.Add(vendas);
            _bancoContext.SaveChanges();
            return vendas;
        }

        public bool Deletar(int id)
        {
            VendasModel vendasDB = ListarPorId(id);

            if (vendasDB == null) throw new Exception("Houve um erro ao apagar a venda!");

            _bancoContext.Vendas.Remove(vendasDB);
            _bancoContext.SaveChanges();
            return true;
        }

    }
}
