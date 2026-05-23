using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotaractERP.Domain.Entities;
using RotaractERP.Domain.ValueObjects.CPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaractERP.Infrastructure.Configurations
{
    public class PessoaFisicaConfiguration : IEntityTypeConfiguration<PessoaFisica>
    {
        public void Configure(EntityTypeBuilder<PessoaFisica> builder)
        {
            builder.OwnsOne(x => x.Cpf, cpf =>
            {
                cpf.Property(x => x.Numero).HasColumnName("Cpf").HasMaxLength(11).IsRequired();

                cpf.HasIndex(x => x.Numero).IsUnique();
            });

        }
    }
}
