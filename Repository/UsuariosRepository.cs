using SistemaDeGestao.Data;
using SistemaDeGestao.Interface;
using SistemaDeGestao.Models;

namespace SistemaDeGestao.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly BancoContent _context;
        public UsuariosRepository (BancoContent bancoContent)
        {
            _context = bancoContent;
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuarios)
        {
            usuarios.DataCadastro = DateTime.Now;
            _context.Usuarios.Add(usuarios);
            _context.SaveChanges();
            return usuarios;
        }
        public UsuarioModel Atualizar(UsuarioModel usuarios)
        {
            UsuarioModel usuariosDB = ListarPorId(usuarios.Id);

            if (usuariosDB == null) throw new Exception("Houve um erro ao atualizar os dados do usuario!");

             usuariosDB.Nome = usuarios.Nome;
             usuariosDB.Login = usuarios.Login;
             usuariosDB.Email = usuarios.Email;
             usuariosDB.Perfil = usuarios.Perfil;
             usuariosDB.DataAlteracao = DateTime.Now;

             //_context.Fabricantes.Update(fabricantesDB);
             _context.SaveChanges(true);

             return usuariosDB;
         }

         public bool Deletar(int id)
         {
            UsuarioModel usuariosDB = ListarPorId(id);

             if (usuariosDB == null) throw new Exception("Houve um erro ao apagar o usuário!");

             _context.Usuarios.Remove(usuariosDB);
             _context.SaveChanges();
             return true;

         }
    }
}
