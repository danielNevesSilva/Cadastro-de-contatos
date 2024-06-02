using Microsoft.AspNetCore.Mvc;
using SiteCadastroMVC.Filters;
using SiteCadastroMVC.Models;
using SiteCadastroMVC.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SiteCadastroMVC.Controllers
{

    [PaginaParaUsuarioLogado]
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;
        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public IActionResult Index()
        {
            List<ContatoModel>  contatos = _contatoRepository.BuscarTodos();
            return View(contatos);
        }
        public IActionResult Criar()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Ops, Não conseguimos cadastrar seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }


        public IActionResult Editar(int id)
        {
           ContatoModel contato = _contatoRepository.ListarPorId(id);
            return View(contato);
        }
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato Alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }

            catch (SystemException erro)
            {
                TempData["MensagemErro"] = $"Ops, Não conseguimos Alterar seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
                throw;
            }
        }
            

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepository.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                _contatoRepository.Apagar(id);
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
