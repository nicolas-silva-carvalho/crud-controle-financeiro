using CRUD.Models;

namespace CRUD.Repository
{
    public interface IUsuarios
    {
        Usuarios BuscarPorLogin(string login);
        Usuarios BuscarPorLoginEEmail(string login, string email);
        Usuarios BuscarUsuariosPorId(int id);
        List<Usuarios> BuscarTodos();
        Usuarios Adicionar(Usuarios usuario);
        Usuarios Atualizar(Usuarios usuarios);
        bool Apagar(int id);

    }
}
