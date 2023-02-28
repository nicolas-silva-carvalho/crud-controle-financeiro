using CRUD.Models;

namespace CRUD.Session
{
    public interface ISessao
    {
        void CriarSessao(Usuarios usuario);
        Usuarios RecuperarSessaoId();
        void RemoverSessaoPorId();
    }
}
