using SistemaDeGestao.Data;
using SistemaDeGestao.Interface;
using SistemaDeGestao.Models;

namespace SistemaDeGestao.Repository
{
    public class FabricantesRepository : IFabricantesRepository
    {
        private readonly BancoContent _context;
        public FabricantesRepository(BancoContent bancoContext)
        {
            _context = bancoContext;
        }

        public FabricantesModel ListarPorId(int id)
        {
            return _context.Fabricantes.FirstOrDefault(x => x.Id == id);
        }

        public List<FabricantesModel> GetAll()
        {
            return _context.Fabricantes.ToList();
        }

        public FabricantesModel Adicionar(FabricantesModel fabricantes)
        {
            _context.Fabricantes.Add(fabricantes);
            _context.SaveChanges();
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

             //_context.Fabricantes.Update(fabricantesDB);
             _context.SaveChanges(true);

             return fabricantesDB;
         }

         public bool Deletar(int id)
         {
             FabricantesModel fabricantesDB = ListarPorId(id);

             if (fabricantesDB == null) throw new Exception("Houve um erro ao apagar os dados do fabricante!");

             _context.Fabricantes.Remove(fabricantesDB);
             _context.SaveChanges();
             return true;

         }
    }
}
