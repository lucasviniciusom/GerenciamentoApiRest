using Microsoft.EntityFrameworkCore;
using gerenciamentoapirest.Models;

namespace gerenciamentoapirest.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Projeto> Projetos { get; set; } // Certifique-se de ter um DbSet para Projeto

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definir o relacionamento entre Tarefa e Projeto
            modelBuilder.Entity<Tarefa>()
                .HasOne(t => t.Projeto)
                .WithMany(p => p.Tarefas)
                .HasForeignKey(t => t.ProjetoId)  // A chave estrangeira � ProjetoId
                .OnDelete(DeleteBehavior.Cascade);  // Quando um Projeto for exclu�do, as Tarefas tamb�m ser�o exclu�das

            // Se voc� tiver outras configura��es, adicione-as aqui
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
