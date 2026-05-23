using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotaractERP.Domain.Entities;

namespace RotaractERP.Infrastructure.Configurations
{
    public class VoluntarioConfiguration : IEntityTypeConfiguration<Voluntario>
    {
        public void Configure(EntityTypeBuilder<Voluntario> builder)
        {
        }
    }
}
