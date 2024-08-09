using SistemaDeGestao.Data;
using SistemaDeGestao.Interface;
using SistemaDeGestao.Models;

namespace SistemaDeGestao.Repository
{
    public class VeiculosRepository : IVeiculosRepository
    {
        private readonly BancoContext _bancoContext;

        public VeiculosRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public VeiculosModel ListarPorId(int id)
        {
            return _bancoContext.Veiculos.FirstOrDefault(x => x.Id == id);
        }

        public List<VeiculosModel> GetAll()
        {
            return _bancoContext.Veiculos.ToList();
        }
        public VeiculosModel Cadastrar(VeiculosModel veiculos)
        {
            _bancoContext.Veiculos.Add(veiculos);
            _bancoContext.SaveChanges();
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

            _bancoContext.Veiculos.Update(veiculosDB);
            _bancoContext.SaveChanges(true);

            return veiculosDB;

        }
        public bool Deletar(int id)
        {
            VeiculosModel veiculosDB = ListarPorId(id);

            if (veiculosDB == null) throw new Exception("Houve um erro ao apagar os dados do veículo!");

            _bancoContext.Veiculos.Remove(veiculosDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
