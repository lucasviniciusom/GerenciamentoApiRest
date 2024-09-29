using gerenciamentoapirest.Data;
using gerenciamentoapirest.Models;
using Microsoft.EntityFrameworkCore;

namespace gerenciamentoapirest.Repositories
{
    public interface ITarefaRepository : IRepository<Tarefa> {
    }
    
    public class TarefaRepository : Repository<Tarefa, ApiDbContext>, ITarefaRepository
    {
        public TarefaRepository(ApiDbContext context) : base(context) { }
    }
}
