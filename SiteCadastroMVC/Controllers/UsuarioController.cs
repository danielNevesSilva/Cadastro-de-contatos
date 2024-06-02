using Microsoft.AspNetCore.Mvc;
using SiteCadastroMVC.Filters;
using SiteCadastroMVC.Models;
using SiteCadastroMVC.Repository;

namespace SiteCadastroMVC.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepository.BuscarTodos();
            return View(usuarios);
        }
        public IActionResult Criar()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepository.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Ops, Não conseguimos cadastrar seu Usuario, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepository.ListarPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Alterar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null;
                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = (Enums.PerfilEnum)usuarioSemSenhaModel.Perfil
                    };


                   usuario = _usuarioRepository.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuario foi Alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }

            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Ops, Não conseguimos Alterar seu Usuario, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
                throw;
            }
        }


        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepository.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                _usuarioRepository.Apagar(id);
                TempData["MensagemSucesso"] = "Contato Apagado com sucesso";
                return RedirectToAction("Index");
            }
            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Ops, Não conseguimos Alterar seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
                throw;
            }


        }
    }
}
