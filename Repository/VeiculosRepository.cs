using SistemaDeGestao.Data;
using SistemaDeGestao.Interface;
using SistemaDeGestao.Models;

namespace SistemaDeGestao.Repository
{
    public class VeiculosRepository : IVeiculosRepository
    {
        private readonly BancoContent _context;

        public VeiculosRepository(BancoContent bancoContext)
        {
            _context = bancoContext;
        }

        public VeiculosModel ListarPorId(int id)
        {
            return _context.Veiculos.FirstOrDefault(x => x.Id == id);
        }

        public List<VeiculosModel> GetAll()
        {
            return _context.Veiculos.ToList();
        }
        public VeiculosModel Adicionar(VeiculosModel veiculos)
        {
            _context.Veiculos.Add(veiculos);
            _context.SaveChanges();
            return veiculos;
        }

        public VeiculosModel Atualizar(VeiculosModel veiculos)
        {
            VeiculosModel veiculosDB = ListarPorId(veiculos.Id);
            if (veiculosDB == null) throw new Exception("Houve um erro ao atualizar os dados do veículo!");

            veiculosDB.Modelo = veiculos.Modelo;
            veiculosDB.AnoFabricacao = veiculos.AnoFabricacao;
            veiculosDB.Preco = veiculos.Preco;
            veiculosDB.Fabricante = veiculos.Fabricante;
            veiculosDB.TipoVeiculo = veiculos.TipoVeiculo;
            veiculosDB.Descricao = veiculos.Descricao;

            _context.Veiculos.Update(veiculosDB);
            _context.SaveChanges(true);

            return veiculosDB;

        }
        public bool Deletar(int id)
        {
            VeiculosModel veiculosDB = ListarPorId(id);

            if (veiculosDB == null) throw new Exception("Houve um erro ao apagar os dados do veículo!");

            _context.Veiculos.Remove(veiculosDB);
            _context.SaveChanges();
            return true;
        }
    }
}
