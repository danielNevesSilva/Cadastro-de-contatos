using Microsoft.EntityFrameworkCore;
using SiteCadastroMVC.Models;

namespace SiteCadastroMVC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
            
        }
        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; } // nome da tabela do banco
    }
}
