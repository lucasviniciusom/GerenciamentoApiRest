using gerenciamentoapirest.Data;
using gerenciamentoapirest.Models;
using gerenciamentoapirest.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace gerenciamentoapirest.Services
{
    public interface ITarefaService : IService<Tarefa>
    {
        Task<List<Tarefa>> GetTarefasByProjetoAsync(int projectId);
    }

    public class TarefaService : Service<Tarefa, ApiDbContext>, ITarefaService
    {
        public TarefaService(ITarefaRepository repository) : base(repository)
        {
        }

        // Método para obter todas as tarefas de um projeto específico
        public async Task<List<Tarefa>> GetTarefasByProjetoAsync(int projectId)
        {
            // Utilizando o repositório para acessar o banco de dados
            return await _repository.GetAllAsync(
                page: 1,
                pageSize: 100,
                whereClause: t => t.ProjetoId == projectId
            ).ContinueWith(task => task.Result.Items.ToList());  // Acessa os itens retornados pelo GetAllAsync
        }
    }
}
