using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotaractERP.Domain.Entities;
using System.Reflection.Emit;

namespace RotaractERP.Infrastructure.Configurations
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.OwnsOne(x => x.Endereco);
            builder.OwnsOne(x => x.Email);
            builder.OwnsOne(x => x.Telefone);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
        }
    }
}
