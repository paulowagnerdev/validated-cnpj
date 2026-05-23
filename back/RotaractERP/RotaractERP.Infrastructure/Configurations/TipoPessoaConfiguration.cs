using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotaractERP.Domain.Entities;

namespace RotaractERP.Infrastructure.Configurations
{
    public class TipoPessoaConfiguration : IEntityTypeConfiguration<TipoPessoa>
    {
        public void Configure(EntityTypeBuilder<TipoPessoa> builder)
        {
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
        }
    }
}
