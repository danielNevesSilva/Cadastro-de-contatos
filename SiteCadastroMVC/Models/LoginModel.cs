using System.ComponentModel.DataAnnotations;

namespace SiteCadastroMVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digita o Login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digita o Senha do usuário")]
        public string Senha { get; set; }
    }
}
