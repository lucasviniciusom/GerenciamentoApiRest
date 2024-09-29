using Microsoft.EntityFrameworkCore;
using gerenciamentoapirest.Models;

namespace gerenciamentoapirest.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}