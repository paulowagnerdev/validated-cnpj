using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotaractERP.Domain.Entities;

namespace RotaractERP.Infrastructure.Configurations
{
    public class CaixaConfiguration : IEntityTypeConfiguration<Caixa>
    {
        public void Configure(EntityTypeBuilder<Caixa> builder)
        {
            builder.ToTable("caixa");

            builder.HasKey(t => t.Id);

            builder.HasOne(x => x.Clube).WithMany(x => x.Caixas).HasForeignKey(x => x.ClubeId).IsRequired();

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
        }
    }
}
