using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class ControleFinanceiro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo produto não pode estar vazio.")]
        public string Produto { get; set; } = "Produto";

        [Range(1, 72, ErrorMessage = "A quantidade de parcelas deve estar entre 1 a 72 vezes.")]
        public int QtdParcelas { get; set; }

        [Range(1.0, 79228162514264, ErrorMessage = "O preço do produto deve ser um número positivo.")]
        public decimal Precototal { get; set; }

        public decimal? PrecoPorParcela { get; set; }
        [Required(ErrorMessage = "O campo descrição não pode estar vazio.")]
        public string Descricao { get; set; }
        public DateTime DataCompra { get; set; }
        public DateTime UltimoDiaParcela { get; set; }
        public int UsuariosId { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
