namespace CRUD.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Username { get; set;}
        public string Password { get; set;}
        public UsuariosEnum UsuariosEnum { get; set; }
        public DateTime DataCadastro { get; set; } 
        public virtual List<ControleFinanceiro> ControleFinanceiro { get; set; }
    }
}
