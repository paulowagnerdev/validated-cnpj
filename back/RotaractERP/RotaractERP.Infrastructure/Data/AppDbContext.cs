using Microsoft.EntityFrameworkCore;
using RotaractERP.Domain.Entities;

namespace RotaractERP.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Caixa> Caixa { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Clube> Clubes { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<TipoPessoa> TipoPessoas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Voluntario> Voluntarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AppDbContext).Assembly);
        }     

    }
}
