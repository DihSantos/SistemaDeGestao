using SistemaDeGestao.Models;

namespace SistemaDeGestao.Helper
{
    public interface ISessao
    {
        void CriarSessaoUsuario(UsuarioModel usuario);
        void RemoveSessaoUsuario();
        UsuarioModel GetSessaoUsuario();
    }
}
