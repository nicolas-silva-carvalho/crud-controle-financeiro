using CRUD.Data.Map;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<ControleFinanceiro> ControleFinanceiros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ControleFinanceiroMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
