using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotaractERP.Domain.Entities;
using RotaractERP.Domain.ValueObjects.CNPJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaractERP.Infrastructure.Configurations
{
    public class PessoaJuridicaConfiguration : IEntityTypeConfiguration<PessoaJuridica>
    {
        public void Configure(EntityTypeBuilder<PessoaJuridica> builder)
        {
            builder.OwnsOne(x => x.Cnpj, Cnpj =>
            {
                Cnpj.Property(x => x.Numero).HasColumnName("Cnpj").HasMaxLength(14);

                Cnpj.HasIndex(x => x.Numero).IsUnique();
            });
        }
    }
}
