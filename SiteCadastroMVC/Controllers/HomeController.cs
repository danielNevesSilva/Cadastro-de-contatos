using Microsoft.AspNetCore.Mvc;
using SiteCadastroMVC.Filters;
using SiteCadastroMVC.Models;
using System.Diagnostics;

namespace SiteCadastroMVC.Controllers
{
    [PaginaParaUsuarioLogado]
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            ContatoModel home = new ContatoModel();

            return View(home);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
