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
    public class TarefaServices : Service<Tarefa, ApiDbContext>, ITarefaService
    {
        private readonly GoogleCalendarService _googleCalendarService;

        public TarefaServices(ITarefaRepository repository, GoogleCalendarService googleCalendarService) : base(repository)
        {
            _googleCalendarService = googleCalendarService;
        }

        public override async Task AddAsync(Tarefa tarefa)
        {
            await base.AddAsync(tarefa);

            // Adiciona o evento no Google Calendar
            _googleCalendarService.CreateEventAsTarefa(tarefa);
            
        }
    }

}
