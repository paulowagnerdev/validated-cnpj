using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotaractERP.Domain.Entities;

namespace RotaractERP.Infrastructure.Configurations
{
    public class LancamentoConfiguration : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.Property(x => x.Tipo).IsRequired();
            builder.HasOne(x => x.Caixa).WithMany(x => x.Lancamentos).HasForeignKey(x => x.CaixaId);
            builder.HasOne(x => x.Categoria).WithMany(x => x.Lancamentos).HasForeignKey(x => x.CategoriaId);
            builder.HasOne(x => x.Pessoa).WithMany(x => x.Lancamentos).HasForeignKey(x => x.PessoaId);
            builder.HasOne(x => x.Voluntario).WithMany(x => x.Lancamentos).HasForeignKey(x => x.VoluntarioId);
        }
    }
}
