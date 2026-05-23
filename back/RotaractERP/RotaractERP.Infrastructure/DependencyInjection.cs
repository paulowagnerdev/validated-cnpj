using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RotaractERP.Infrastructure.Data;

namespace RotaractERP.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            return services;
        }
    }
}
