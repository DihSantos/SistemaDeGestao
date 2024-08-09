﻿using SistemaDeGestao.Models;

namespace SistemaDeGestao.Interface
{
    public interface IVendasRepository
    {
        VendasModel ListarPorId(int id);
        List<VendasModel> GetAll();
        VendasModel Registrar(VendasModel vendas);
        bool Deletar(int id);
    }
}
