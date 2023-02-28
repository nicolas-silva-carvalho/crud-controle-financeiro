using CRUD.Models;
using CRUD.Repository;
using CRUD.Session;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarios _usuarios;
        private readonly ISessao _sessao;

        public LoginController(IUsuarios usuarios, ISessao sessao)
        {
            _usuarios = usuarios;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            if (_sessao.RecuperarSessaoId() != null) return RedirectToAction("Index", "Logado");
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuarios usuario = _usuarios.BuscarPorLoginESenha(login.Username, login.Password);

                    if(usuario != null)
                    {
                        _sessao.CriarSessao(usuario);
                        return RedirectToAction("Index", "Logado");
                    }
                }
                return View(login);
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro {ex.Message}");
            }
        }

        public IActionResult CriarConta()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CriarConta(Usuarios usuario)
        {
            try
            {
                usuario = _usuarios.Adicionar(usuario);
                return RedirectToAction("CriarConta");
            }
            catch (Exception ex)
            {
                return RedirectToAction("CriarConta");
                throw new Exception($"Erro ao cadastrar usuário. Erro:{ex.Message}");
            }
        }
    }
}
