using SiteCadastroMVC.Models;

namespace SiteCadastroMVC.Repository
{
    public interface IContatoRepository
    {
        ContatoModel ListarPorId(int id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        
        bool Apagar(int id);
    }
}
