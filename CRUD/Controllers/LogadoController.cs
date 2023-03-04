using CRUD.Models;
using CRUD.Repository;
using CRUD.Session;
using Microsoft.AspNetCore.Mvc;
using CRUD.Data;
using Microsoft.EntityFrameworkCore;
using CRUD.Funcoes;

namespace CRUD.Controllers
{
    public class LogadoController : Controller
    {
        private readonly IControleFinanceiro _controleFinanceiro;
        private readonly ISessao _sessao;
        private readonly Contexto _contexto;
        public LogadoController(IControleFinanceiro controleFinanceiro, ISessao sessao, Contexto contexto)
        {
            _controleFinanceiro = controleFinanceiro;
            _sessao = sessao;
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            Usuarios usuariosLogado = _sessao.RecuperarSessaoId();
            List<ControleFinanceiro> controleFinanceiro = _controleFinanceiro.BuscarTodos(usuariosLogado.Id);
            return View(controleFinanceiro);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(ControleFinanceiro controleFinanceiro)
        {
            try
            {
                Usuarios usuarioLogado = _sessao.RecuperarSessaoId();
                controleFinanceiro.UsuariosId = usuarioLogado.Id;

                if (controleFinanceiro.QtdParcelas > 0)
                {
                    controleFinanceiro = _controleFinanceiro.Adicionar(controleFinanceiro);
                    TempData["Sucesso"] = "Produto Adicionado com sucesso";
                    return RedirectToAction("Adicionar");
                }

                TempData["Error"] = "Erro ao cadastrar compra.";
                return View(controleFinanceiro);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoPorId();
            return RedirectToAction("Login", "Login");
        }

        public IActionResult Grafico()
        {
            Usuarios usuario = _sessao.RecuperarSessaoId();
            var resultado = _controleFinanceiro.BuscarTodos(usuario.Id).GroupBy(x => x.Produto).Select(g => new { g.Key, TotalComprado = g.Sum(x => x.Precototal) });

            string dados = "";

            foreach (var item in resultado)
            {
                dados += "['" + item.Key + "'," + item.TotalComprado.ToString().Replace(",", ".") + "],";
            }

            dados = dados.Substring(0, dados.Length - 1);
            ViewBag.GraficoPizza = GoogleChart.GerarGraficoPizza("Total de compra por Produto", dados);
            return View();
        }

        public IActionResult GraficoChart()
        {
            return View();
        }

        [HttpPost]
        public List<object> GraficoCharts()
        {
            Usuarios usuario = _sessao.RecuperarSessaoId();
            List<object> data = new List<object>();

            List<string> label = _controleFinanceiro.BuscarTodos(usuario.Id).Select(p => p.Produto).ToList();

            data.Add(label);

            List<decimal> preco = _controleFinanceiro.BuscarTodos(usuario.Id).Select(p => p.Precototal).ToList();

            data.Add(preco);
            return data;
        }
    }
}
