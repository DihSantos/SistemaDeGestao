using GestaoDeVendas.Models;

namespace GestaoDeVendas.Interface
{
    public interface IVendasService
    {
        public bool PrecoValido(float preco,int idVeiculo);
    }
}
