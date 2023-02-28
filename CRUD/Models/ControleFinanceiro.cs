namespace CRUD.Models
{
    public class ControleFinanceiro
    {
        public int Id { get; set; }
        public string Produto { get; set; }
        public int QtdParcelas { get; set; }
        public decimal Precototal { get; set; }
        public decimal? PrecoPorParcela { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCompra { get; set; }
        public DateTime UltimoDiaParcela { get; set; }
        public int UsuariosId { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
