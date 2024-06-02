using System.ComponentModel.DataAnnotations;

namespace SiteCadastroMVC.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digita o Login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digita o Senha do Email")]
        public string Email { get; set; }
    }
}
