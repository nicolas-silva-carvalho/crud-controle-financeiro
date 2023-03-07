using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class RecuperarSenhaModel
    {
        [Required(ErrorMessage = "Informe o login")]
        public string Login { get; set; }
    }
}
