using System.ComponentModel.DataAnnotations;

namespace SiteCadastroMVC.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Digite o Nome do contato")]
        public String Nome { get; set; }
        [Required (ErrorMessage = "Digite o Email do contato")]
        [EmailAddress (ErrorMessage ="O Email informado não é valido!")]
        public String Email { get; set; }
        [Required (ErrorMessage = "Digite o Celular do contato")]
        [Phone(ErrorMessage ="O Celular informado não é valido")]
        public String Celular { get; set; }

        public ContatoModel()
        {
            
        }
    }
}
