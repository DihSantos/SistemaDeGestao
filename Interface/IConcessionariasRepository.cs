using GestaoDeVendas.Models;

namespace GestaoDeVendas.Interface
{
    public interface IConcessionariasRepository
    {        
        ConcessionariasModel ListarPorId(int id);
        List<ConcessionariasModel> GetAll();
        ConcessionariasModel Adicionar(ConcessionariasModel concessionarias);
        ConcessionariasModel Atualizar(ConcessionariasModel concessionarias);
        bool Deletar(int id);
    }
}
