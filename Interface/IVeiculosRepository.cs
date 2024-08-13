using SistemaDeGestao.Models;

namespace SistemaDeGestao.Interface
{
    public interface IVeiculosRepository
    {
        VeiculosModel ListarPorId(int id);
        List<VeiculosModel> GetAll();
        VeiculosModel Adicionar(VeiculosModel veiculos);
        VeiculosModel Atualizar(VeiculosModel veiculos);
        bool Deletar(int id);
    }
}
