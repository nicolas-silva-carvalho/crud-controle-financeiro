using CRUD.Models;

namespace CRUD.Repository
{
    public interface IUsuarios
    {
        Usuarios BuscarPorLoginESenha(string login, string senha);
        Usuarios BuscarUsuariosPorId(int id);
        List<Usuarios> BuscarTodos();
        Usuarios Adicionar(Usuarios usuario);
        bool Apagar(int id);

    }
}
