using SistemaDeGestao.Models;

namespace SistemaDeGestao.Interface
{
    public interface IRelatorioVendasRepository
    {
        public IQueryable<VendasDto> FiltrarVendas(VendasFiltro filtro);
    }
}
