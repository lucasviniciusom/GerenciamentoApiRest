using gerenciamentoapirest.Services;
using gerenciamentoapirest.Models;

namespace gerenciamentoapirest.Controllers
{
    public class ProjetosController : BaseController<Projeto, IProjetoService>
    {
        public ProjetosController(IProjetoService service) : base(service)
        {

        }
    }
}
