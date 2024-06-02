using Microsoft.AspNetCore.Mvc;
using SiteCadastroMVC.Helper;
using SiteCadastroMVC.Models;
using SiteCadastroMVC.Repository;

namespace SiteCadastroMVC.Controllers
{
    public class AlterarSenhaController : Controller
       
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessao _sessao;
        public AlterarSenhaController(IUsuarioRepository usuarioRepository,
                                        ISessao sessao)
        {
            _usuarioRepository = usuarioRepository;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {
                UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                alterarSenhaModel.Id = usuarioLogado.Id;
                if (ModelState.IsValid)
                {

                    _usuarioRepository.AlterarSenha(alterarSenhaModel);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso";
                    return View("Index", alterarSenhaModel);
                }
                return View("Index", alterarSenhaModel);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, Não conseguimos cadastrar sua Senha, tente novamente, detalhe do erro: {erro.Message}";
                return View("Index", alterarSenhaModel);
            }
        }
    }
}
