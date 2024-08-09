using GestaoDeVendas.Data;
using GestaoDeVendas.Interface;
using GestaoDeVendas.Models;

namespace GestaoDeVendas.Repository
{
    public class ConcessionariasRepository : IConcessionariasRepository
    {
        private readonly BancoContext _bancoContext;
        public ConcessionariasRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ConcessionariasModel ListarPorId(int id)
        {
            return _bancoContext.Concessionarias.FirstOrDefault(x => x.Id == id);
        }

        public List<ConcessionariasModel> GetAll()
        {
            return _bancoContext.Concessionarias.ToList();
        }

        public ConcessionariasModel Adicionar(ConcessionariasModel concessionarias)
        {
            _bancoContext.Concessionarias.Add(concessionarias);
            _bancoContext.SaveChanges();
            return concessionarias;
        }
        public ConcessionariasModel Atualizar(ConcessionariasModel concessionarias)
        {
            ConcessionariasModel concessionariasDB = ListarPorId(concessionarias.Id);

            if (concessionariasDB == null) throw new Exception("Houve um erro ao atualizar os dados do fabricante!");

            concessionariasDB.Concessionaria = concessionarias.Concessionaria;
            concessionariasDB.Rua = concessionarias.Rua;
            concessionariasDB.Cidade = concessionarias.Cidade;
            concessionariasDB.Estado = concessionarias.Estado;
            concessionariasDB.CEP = concessionarias.CEP;
            concessionariasDB.Telefone = concessionarias.Telefone;
            concessionariasDB.Email = concessionarias.Email;
            concessionariasDB.CapacidadeVeiculos = concessionarias.CapacidadeVeiculos;

            _bancoContext.Concessionarias.Update(concessionariasDB);
            _bancoContext.SaveChanges(true);

            return concessionariasDB;
        }

        public bool Deletar(int id)
        {
            ConcessionariasModel concessionariasDB = ListarPorId(id);

            if (concessionariasDB == null) throw new Exception("Houve um erro ao apagar os dados do fabricante!");

            _bancoContext.Concessionarias.Remove(concessionariasDB);
            _bancoContext.SaveChanges();
            return true;

        }
    }
}
