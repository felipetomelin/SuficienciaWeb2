using Microsoft.EntityFrameworkCore;
using SuficienciaWebII.Entities;

namespace SuficienciaWebII.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }
    }
}