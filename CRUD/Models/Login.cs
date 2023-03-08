using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Nome de usuário obrigatório")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Senha de usuário obrigatório")]
        public string Password { get; set; }
    }
}
