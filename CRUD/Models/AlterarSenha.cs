using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class AlterarSenha
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A senha atual é obrigatória.")]
        public string SenhaAtual { get; set; }
        [Required(ErrorMessage = "A nova senha é obrigatória.")]
        public string NovaSenha { get; set; }
        [Required(ErrorMessage = "Confirmar a senha é obrigatório.")]
        public string ConfirmaSenha { get; set; }
    }
}
