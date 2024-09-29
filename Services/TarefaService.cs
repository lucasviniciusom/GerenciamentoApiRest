using gerenciamentoapirest.Data;
using gerenciamentoapirest.Models;
using gerenciamentoapirest.Repositories;

namespace gerenciamentoapirest.Services
{
    public interface ITarefaService : IService<Tarefa> {

    }

    public class TarefaService : Service<Tarefa, ApiDbContext>, ITarefaService
    {

        public TarefaService(ITarefaRepository repository) : base(repository)
        {

        }
    }
}
