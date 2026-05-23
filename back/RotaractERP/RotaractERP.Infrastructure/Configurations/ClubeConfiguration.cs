using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotaractERP.Domain.Entities;
using RotaractERP.Domain.ValueObjects.CNPJ;
using System.Reflection.Emit;

namespace RotaractERP.Infrastructure.Configurations
{
    public class ClubeConfiguration : IEntityTypeConfiguration<Clube>
    {
        public void Configure(EntityTypeBuilder<Clube> builder)
        {
            builder.OwnsOne(x => x.Email);
            builder.OwnsOne(x => x.Cnpj);
            builder.OwnsOne(x => x.Telefone);

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);

            builder.OwnsOne(x => x.Cnpj, Cnpj =>
            {
                Cnpj.Property(x => x.Numero).HasColumnName("Cnpj").HasMaxLength(14);
            });
        }
    }
}
