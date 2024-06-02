using Microsoft.AspNetCore.Mvc;
using SiteCadastroMVC.Filters;

namespace SiteCadastroMVC.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
