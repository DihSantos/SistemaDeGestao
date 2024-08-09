using SistemaDeGestao.Models;

namespace SistemaDeGestao.Interface
{
    public interface IVendasRepository
    {
        VendasModel ListarPorId(int ProtocoloVenda);
        List<VendasModel> GetAll();
        VendasModel Registrar(VendasModel vendas);
        bool Deletar(int ProtocoloVenda);
    }
}
