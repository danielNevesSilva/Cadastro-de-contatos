using SiteCadastroMVC.Enums;
using SiteCadastroMVC.Helper;
using System.ComponentModel.DataAnnotations;

namespace SiteCadastroMVC.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digita o Login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digita o Email do usuário")]
        [EmailAddress(ErrorMessage ="O Email informado não é valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digita o Senha do usuário")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Informa o perfil do usuário")]
        public PerfilEnum Perfil { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();

        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public UsuarioModel()
        {
            DataCadastro = DateTime.Now;
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            return novaSenha;

        }

        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }
    }
}
