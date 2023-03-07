using CRUD.Helper;
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
        private readonly IEmail _email;

        public LoginController(IUsuarios usuarios, ISessao sessao, IEmail email)
        {
            _usuarios = usuarios;
            _sessao = sessao;
            _email = email;
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
                    Usuarios usuario = _usuarios.BuscarPorLogin(login.Username);

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

        [HttpPost]
        public IActionResult RecuperarSenha()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarLinkParaRedefinirSenha(RecuperarSenhaModel recuperarSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuarios usuario = _usuarios.BuscarPorLoginEEmail(recuperarSenhaModel.Login, recuperarSenhaModel.Email);

                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();

                        string mensagem = $"Sua nova senha: {novaSenha}";

                        bool emailEnviado = _email.Enviar(usuario.Email, "Controle Financeiro - Nova Senha", mensagem);

                        if(emailEnviado)
                        {
                            _usuarios.Atualizar(usuario);
                            TempData["Sucesso"] = "Nova senha enviado para o email cadastrado";
                        }
                        else
                        {
                            TempData["Error"] = "Não foi possivel enviar e-mail para redefinir sua senha.";
                        }

                        return RedirectToAction("Login");

                    }
                    TempData["Error"] = "Não foi possivel redefinir sua senha.";
                }
                return View();
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro {ex.Message}");
            }
        }
    }
}
