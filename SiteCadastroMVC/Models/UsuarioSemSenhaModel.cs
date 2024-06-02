using SiteCadastroMVC.Enums;
using System.ComponentModel.DataAnnotations;

namespace SiteCadastroMVC.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digita o Login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digita o Email do usuário")]
        [EmailAddress(ErrorMessage ="O Email informado não é valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informa o perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }
        
    }
}
