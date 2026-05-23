using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotaractERP.Domain.Entities;
using System.Reflection.Emit;

namespace RotaractERP.Infrastructure.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.OwnsOne(x => x.Email);

            builder.HasIndex(x => x.Login).IsUnique();
            builder.Property(x => x.Login).IsRequired();
        }
    }
}
