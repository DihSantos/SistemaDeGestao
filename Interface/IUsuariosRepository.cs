﻿using SistemaDeGestao.Models;

namespace SistemaDeGestao.Interface
{
    public interface IUsuariosRepository
    {
        UsuarioModel GetLogin(string login);
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> GetAll();
        UsuarioModel Adicionar(UsuarioModel fabricantes);
        UsuarioModel Atualizar(UsuarioModel fabricantes);
        bool Deletar(int id);
    }
}
