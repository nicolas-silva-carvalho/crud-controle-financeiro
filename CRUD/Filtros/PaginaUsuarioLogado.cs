using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace CRUD.Filtros
{
    public class PaginaUsuarioLogado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("SessaoLogado");

            if(string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { {"controller", "Login" }, { "action", "Index" } });
            }
            else
            {
                Usuarios usuario = JsonConvert.DeserializeObject<Usuarios>(sessaoUsuario);
                if(usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
