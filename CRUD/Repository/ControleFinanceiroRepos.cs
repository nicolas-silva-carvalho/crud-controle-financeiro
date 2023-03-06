using CRUD.Data;
using CRUD.Models;

namespace CRUD.Repository
{
    public class ControleFinanceiroRepos : IControleFinanceiro
    {
        private readonly Contexto _contexto;

        public ControleFinanceiroRepos(Contexto contexto)
        {
            _contexto = contexto;
        }

        public ControleFinanceiro Adicionar(ControleFinanceiro controleFinanceiro)
        {
            _contexto.ControleFinanceiros.Add(controleFinanceiro);
            controleFinanceiro.QuantidadeDeProdutos = 1;
            controleFinanceiro.PrecoPorParcela = (decimal)(controleFinanceiro.Precototal / controleFinanceiro.QtdParcelas);
            var date = controleFinanceiro.DataCompra = DateTime.UtcNow;
            controleFinanceiro.UltimoDiaParcela = date.AddMonths(controleFinanceiro.QtdParcelas);
            _contexto.SaveChanges();
            return controleFinanceiro;
        }

        public bool Apagar(int id)
        {
            ControleFinanceiro controleFinanceiro = BuscarPorId(id);
            _contexto.ControleFinanceiros.Remove(controleFinanceiro);
            _contexto.SaveChanges();
            return true;
        }

        public ControleFinanceiro Atualizar(ControleFinanceiro controleFinanceiro)
        {
            ControleFinanceiro controleFinanceiroDb = BuscarPorId(controleFinanceiro.Id);
            controleFinanceiroDb.Produto = controleFinanceiro.Produto;
            controleFinanceiroDb.QtdParcelas = controleFinanceiro.QtdParcelas;
            controleFinanceiroDb.Precototal = controleFinanceiro.Precototal;
            controleFinanceiroDb.PrecoPorParcela = (decimal)(controleFinanceiro.Precototal / controleFinanceiro.QtdParcelas);
            controleFinanceiroDb.Descricao = controleFinanceiro.Descricao;
            controleFinanceiroDb.DataCompra = controleFinanceiro.DataCompra;
            controleFinanceiroDb.UltimoDiaParcela = controleFinanceiroDb.DataCompra.AddMonths(controleFinanceiroDb.QtdParcelas);

            _contexto.ControleFinanceiros.Update(controleFinanceiroDb);
            _contexto.SaveChanges();
            return controleFinanceiroDb;
        }

        public ControleFinanceiro BuscarPorId(int id)
        {
            return _contexto.ControleFinanceiros.FirstOrDefault(x => x.Id == id);
        }

        public List<ControleFinanceiro> BuscarTodos(int usuarioId)
        {
            return _contexto.ControleFinanceiros.Where(x => x.UsuariosId== usuarioId).ToList();
        }
    }
}
