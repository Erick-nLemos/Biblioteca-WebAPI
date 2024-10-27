using FirstAPICSharp.models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPICSharp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Criação das Tabelas do DB
        public DbSet<AutorModel> Autores { get; set; }
        public DbSet<LivroModel> Livros { get; set; }

    }
}
