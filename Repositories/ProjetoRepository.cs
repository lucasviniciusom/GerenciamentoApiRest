using gerenciamentoapirest.Data;
using gerenciamentoapirest.Models;
using Microsoft.EntityFrameworkCore;

namespace gerenciamentoapirest.Repositories
{
    public interface IProjetoRepository : IRepository<Projeto>
    {
    }

    public class ProjetoRepository : Repository<Projeto, ApiDbContext>, IProjetoRepository
    {
        public ProjetoRepository(ApiDbContext context) : base(context) { }
    }
}










