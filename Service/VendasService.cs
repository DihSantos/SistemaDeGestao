using SistemaDeGestao.Interface;
using SistemaDeGestao.Models;

namespace SistemaDeGestao.Service
{
    public class VendasService : IVendasService
    {
        private readonly IVendasRepository _vendasRepository;
        private readonly IVeiculosRepository _veiculosRepository;
        private readonly IConcessionariasRepository _concessionariasRepository;
        public VendasService(IVeiculosRepository veiculosRepository, IConcessionariasRepository concessionariasRepository, IVendasRepository vendasRepository)
        {
            _veiculosRepository = veiculosRepository;
            _concessionariasRepository = concessionariasRepository;
            _vendasRepository = vendasRepository;
        }

        public bool PrecoValido(float preco, int idVeiculo)
        {
            VeiculosModel Veiculo = _veiculosRepository.ListarPorId(idVeiculo);
            float precoVeiculo = Veiculo.Preco;
            if (preco <= precoVeiculo) return true;

            return false;

        }
    }
}
