using SistemaDeGestao.Data;
using SistemaDeGestao.Models;
using Microsoft.EntityFrameworkCore;
using SistemaDeGestao.Interface;

namespace SistemaDeGestao.Repository
{
    public class RelatorioVendasRepository : IRelatorioVendasRepository 
    {
        private readonly BancoContent _context;

        public RelatorioVendasRepository(BancoContent context) 
        {
            _context = context;
        }


        public IQueryable<VendasDto> FiltrarVendas(VendasFiltro filtro)
        {
            var query = _context.Vendas
                                .Include(p => p.Concessionarias)
                                .Include(p => p.Veiculos)
                                .AsQueryable();

            if (!string.IsNullOrEmpty(filtro.Concessionaria))
            {
                query = query.Where(p => p.Concessionaria.Contains(filtro.Concessionaria));
            }

            if (!string.IsNullOrEmpty(filtro.Fabricante))
            {
                query = query.Where(p => p.Veiculos.Fabricante.Contains(filtro.Fabricante));
            }
            if (!string.IsNullOrEmpty(filtro.TipoVeiculo))
            {
                query = query.Where(p => p.Veiculos.TipoVeiculo.Contains(filtro.TipoVeiculo));
            }
            if (!filtro.DataVendaMin.HasValue)
            {
                query = query.Where(p => p.DataVenda >= filtro.DataVendaMin.Value);
            }
            if (filtro.DataVendaMax.HasValue)
            {
                query = query.Where(p => p.DataVenda <= filtro.DataVendaMax.Value);
            }

            return query.Select(p => new VendasDto
            {
                Id = p.Id,
                ProtocoloVenda = p.ProtocoloVenda,
                Fabricante = p.Veiculos.Fabricante,
                Concessionaria = p.Concessionaria,
                TipoVeiculo = p.Veiculos.TipoVeiculo,
                VeiculoModelo = p.Veiculos.Modelo,
                PrecoVenda = p.PrecoVenda,
                DataVenda = p.DataVenda
            });
        }
    }
}

