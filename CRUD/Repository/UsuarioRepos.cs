using CRUD.Data;
using CRUD.Models;

namespace CRUD.Repository
{
    public class UsuarioRepos : IUsuarios
    {
        private readonly Contexto contexto;

        public UsuarioRepos(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public Usuarios Adicionar(Usuarios usuario)
        {
            contexto.Usuarios.Add(usuario);
            usuario.DataCadastro = DateTime.UtcNow;
            contexto.SaveChanges();
            return usuario;

        }

        public bool Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public Usuarios BuscarPorLoginESenha(string login, string senha)
        {
            return contexto
                .Usuarios
                .FirstOrDefault(x => x.Username.ToUpper() == login.ToUpper() && x.Password.ToUpper() == senha.ToUpper());
        }

        public List<Usuarios> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public Usuarios BuscarUsuariosPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
