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
                    Usuarios usuario = _usuarios.BuscarPorLoginESenha(login.Username);

                    if(usuario != null)
                    {
                        if (usuario.SenhaValida(login.Password))
                        {
                            _sessao.CriarSessao(usuario);
                            return RedirectToAction("Index", "Logado");
                        }
                    }
                    TempData["Error"] = "Usuário ou senha inválidas.";
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
                if(!ModelState.IsValid)
                { 
                    usuario = _usuarios.Adicionar(usuario);
                    TempData["Sucesso"] = "Usuário cadastrado com sucesso";
                    return RedirectToAction("CriarConta");
                }
                return View();
                
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Erro ao cadastrar usuário.";
                return View("CriarConta");
                throw new Exception($"Erro ao cadastrar usuário. Erro:{ex.Message}");
                
            }
        }

        public IActionResult RecuperarSenha(RecuperarSenhaModel model)
        {
            ViewBag.EmailEnviado = true;
            if (HttpContext.Request.Method.ToUpper() == "GET")
            {
                ViewBag.EmailEnviado = false;
                ModelState.Clear();
            }
            return View(model);
        }
    }
}
