
using SiteCadastroMVC.Models;

namespace SiteCadastroMVC.Repository
{
    public interface IUsuarioRepository
    {
        UsuarioModel BuscarPorLogin(string login);

        UsuarioModel BuscarPorEmailELogin(string email, string login);

        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);

        UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel);

        bool Apagar(int id);
    }
}
