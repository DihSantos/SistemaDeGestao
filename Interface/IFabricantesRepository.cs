using GestaoDeVendas.Models;

namespace GestaoDeVendas.Interface
{
    public interface IFabricantesRepository
    {
        FabricantesModel ListarPorId(int id);
        List<FabricantesModel> GetAll();
        FabricantesModel Adicionar(FabricantesModel fabricantes);
        FabricantesModel Atualizar(FabricantesModel fabricantes);
        bool Deletar(int id);
    }
}
