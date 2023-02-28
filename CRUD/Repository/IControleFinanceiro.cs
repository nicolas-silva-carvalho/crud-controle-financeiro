using CRUD.Models;

namespace CRUD.Repository
{
    public interface IControleFinanceiro
    {
        List<ControleFinanceiro> BuscarTodos(int usuarioId);
        ControleFinanceiro Atualizar(ControleFinanceiro controleFinanceiro);
        ControleFinanceiro Adicionar(ControleFinanceiro controleFinanceiro);
        ControleFinanceiro BuscarPorId(int id);
        bool Apagar(int id);
    }
}
