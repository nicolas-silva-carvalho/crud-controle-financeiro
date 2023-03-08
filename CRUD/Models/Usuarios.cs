using CRUD.Helper;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        public string Username { get; set;}
        [Required(ErrorMessage = "A senha é obrigatório.")]
        public string Password { get; set;}
        [Required(ErrorMessage ="O tipo de usuário é obrigatório e deve estar entre 1 para Admin e 2 para padrão.")]
        public UsuariosEnum UsuariosEnum { get; set; }
        public DateTime DataCadastro { get; set; } 
        public virtual List<ControleFinanceiro> ControleFinanceiro { get; set; }

        public bool SenhaValida(string senha)
        {
            return Password == senha.GerarHash();
        }



        public void SetaSenhaHash()
        {
            Password = Password.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Password = novaSenha.GerarHash();
            return novaSenha;
        }
    }
}
