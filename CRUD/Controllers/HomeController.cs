using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}