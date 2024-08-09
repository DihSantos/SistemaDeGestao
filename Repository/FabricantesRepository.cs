using SistemaDeGestao.Data;
using SistemaDeGestao.Interface;
using SistemaDeGestao.Models;

namespace SistemaDeGestao.Repository
{
    public class FabricantesRepository : IFabricantesRepository
    {
        private readonly BancoContext _bancoContext;
        public FabricantesRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public FabricantesModel ListarPorId(int id)
        {
            return _bancoContext.Fabricantes.FirstOrDefault(x => x.Id == id);
        }

        public List<FabricantesModel> GetAll()
        {
            return _bancoContext.Fabricantes.ToList();
        }

        public FabricantesModel Adicionar(FabricantesModel fabricantes)
        {
            _bancoContext.Fabricantes.Add(fabricantes);
            _bancoContext.SaveChanges();
            return fabricantes;
        }
        public FabricantesModel Atualizar(FabricantesModel fabricantes)
        {
            FabricantesModel fabricantesDB = ListarPorId(fabricantes.Id);

            if (fabricantesDB == null) throw new Exception("Houve um erro ao atualizar os dados do fabricante!");

            fabricantesDB.Fabricante = fabricantes.Fabricante;
            fabricantesDB.PaisOrigem = fabricantes.PaisOrigem;
            fabricantesDB.AnoFundacao = fabricantes.AnoFundacao;
            fabricantesDB.Website = fabricantes.Website;

            _bancoContext.Fabricantes.Update(fabricantesDB);
            _bancoContext.SaveChanges(true);

            return fabricantesDB;
        }

        public bool Deletar(int id)
        {
            FabricantesModel fabricantesDB = ListarPorId(id);

            if (fabricantesDB == null) throw new Exception("Houve um erro ao apagar os dados do fabricante!");

            _bancoContext.Fabricantes.Remove(fabricantesDB);
            _bancoContext.SaveChanges();
            return true;

        }
    }
}
