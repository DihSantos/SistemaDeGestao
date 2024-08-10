using SistemaDeGestao.Data;
using SistemaDeGestao.Interface;
using SistemaDeGestao.Models;

namespace SistemaDeGestao.Repository
{
    public class ConcessionariasRepository : IConcessionariasRepository
    {
        private readonly BancoContent _context;
        public ConcessionariasRepository(BancoContent bancoContext)
        {
            _context = bancoContext;
        }

        public ConcessionariasModel ListarPorId(int id)
        {
            return _context.Concessionarias.FirstOrDefault(x => x.Id == id);
        }
       
        public List<ConcessionariasModel> GetAll()
        {
            return _context.Concessionarias.ToList();
        }

        public ConcessionariasModel Adicionar(ConcessionariasModel concessionarias)
        {
            _context.Concessionarias.Add(concessionarias);
            _context.SaveChanges();
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

            //_context.Concessionarias.Update(concessionariasDB);
            _context.SaveChanges(true);

            return concessionariasDB;
        }

        public bool Deletar(int id)
        {
            ConcessionariasModel concessionariasDB = ListarPorId(id);

            if (concessionariasDB == null) throw new Exception("Houve um erro ao apagar os dados do fabricante!");

            _context.Concessionarias.Remove(concessionariasDB);
            _context.SaveChanges();
            return true;

        }
    }
}
