using Chapter.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Chapter.WebAPI.Contexts
{
    public class ChapterContext : DbContext 
    {
        public ChapterContext()
        {
        }
        public ChapterContext(DbContextOptions<ChapterContext> options) : base(options) { }

        protected override void
        OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-N51HK6H\\SQLEXPRESS; initial catalog = Chapter; Integrated Security = true");
            }
        }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
