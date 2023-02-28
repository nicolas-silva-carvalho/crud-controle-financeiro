using CRUD.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CRUD.Session
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            this.httpContext = httpContext;
        }

        public void CriarSessao(Usuarios usuario)
        {
            string sessaoUsuario = JsonConvert.SerializeObject(usuario);

            httpContext.HttpContext.Session.SetString("SessaoLogado", sessaoUsuario);
        }

        public Usuarios RecuperarSessaoId()
        {
            string sessaoUsuario = httpContext.HttpContext.Session.GetString("SessaoLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<Usuarios>(sessaoUsuario);
           
        }

        public void RemoverSessaoPorId()
        {
            httpContext.HttpContext.Session.Remove("SessaoLogado");
        }
    }
}
