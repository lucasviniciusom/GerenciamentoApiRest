using gerenciamentoapirest.Data;
using gerenciamentoapirest.Models;
using gerenciamentoapirest.Repositories;

namespace gerenciamentoapirest.Services
{
    public interface IProjetoService : IService<Projeto>
    {

    }

    public class ProjetoService : Service<Projeto, ApiDbContext>, IProjetoService
    {

        public ProjetoService(IProjetoRepository repository) : base(repository)
        {

        }
    }
}



