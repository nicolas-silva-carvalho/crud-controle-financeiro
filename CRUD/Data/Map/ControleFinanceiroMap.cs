using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Data.Map
{
    public class ControleFinanceiroMap : IEntityTypeConfiguration<ControleFinanceiro>
    {
        public void Configure(EntityTypeBuilder<ControleFinanceiro> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Usuarios);
        }
    }
}
