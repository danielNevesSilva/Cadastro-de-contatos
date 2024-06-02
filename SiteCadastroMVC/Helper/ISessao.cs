using SiteCadastroMVC.Models;

namespace SiteCadastroMVC.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioModel usuario);
        void RemoverSessaoUsuario();
        UsuarioModel BuscarSessaoDoUsuario();

    }
}
