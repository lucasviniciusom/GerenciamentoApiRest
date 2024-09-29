using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using gerenciamentoapirest.Services;
using gerenciamentoapirest.Models;

namespace gerenciamentoapirest.Controllers
{
    public class TarefasController : BaseController<Tarefa, ITarefaService>
    {
        public TarefasController(ITarefaService service) : base(service)
        {
        }
    }
}
