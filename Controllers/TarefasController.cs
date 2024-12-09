using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using gerenciamentoapirest.Services;
using gerenciamentoapirest.Models;

namespace gerenciamentoapirest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : BaseController<Tarefa, ITarefaService>
    {
        public TarefasController(ITarefaService service) : base(service)
        {
        }

        // Método para obter todas as tarefas de um projeto específico
        [HttpGet("Projeto/{projectId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTarefasByProjeto(int projectId)
        {
            try
            {
                var tarefas = await _service.GetTarefasByProjetoAsync(projectId);
                if (tarefas == null || !tarefas.Any())
                {
                    return NotFound(new { message = "Não há tarefas para este projeto." });
                }

                return Ok(tarefas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        // Método para criar uma nova tarefa para um projeto específico
        [HttpPost("Projeto/{projectId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateTarefaForProjeto(int projectId, [FromBody] Tarefa tarefa)
        {
            if (tarefa == null)
            {
                return BadRequest("A tarefa não pode ser nula.");
            }

            try
            {
                tarefa.ProjetoId = projectId; // Associando a tarefa ao projeto
                await _service.AddAsync(tarefa);
                return CreatedAtAction(nameof(GetTarefasByProjeto), new { projectId = projectId }, tarefa);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        // Método para excluir uma tarefa de um projeto específico
        [HttpDelete("Projeto/{projectId}/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTarefa(int projectId, int id)
        {
            try
            {
                var tarefa = await _service.GetByIdAsync(id);
                if (tarefa == null || tarefa.ProjetoId != projectId)
                {
                    return NotFound(new { message = "Tarefa não encontrada ou não pertence a este projeto." });
                }

                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
