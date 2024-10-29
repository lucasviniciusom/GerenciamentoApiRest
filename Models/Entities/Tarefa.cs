using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gerenciamentoapirest.Models
{

    [Table("Tarefas")]
    public class Tarefa: BaseEntity 
    {
        [Required]
        public int TarefaId { get; set; }  // Identificador único da tarefa

        [Required]
        public string Titulo { get; set; }  // Título da tarefa

        [Required]
        public string Descricao { get; set; }  // Descrição da tarefa

        [Required]
        public PrioridadeTarefa Prioridade { get; set; }  // Prioridade: 'alta', 'média', 'baixa'

        [Required]
        public StatusTarefa Status { get; set; }

        [Required]
        public DateTime DataVencimento { get; set; }  // Data de vencimento da tarefa 

        [Required]
        public DateTime CriadoEm { get; set; }  // Data de criação da tarefa


        [Required]
        public int ProjetoId { get; set; }


        public Projeto Projeto { get; set; }



    }

    public enum StatusTarefa
    {
        Não_iniciada,
        Em_andamento,
        Finalizada
    }

    public enum PrioridadeTarefa
    {
        Baixa,
        Média,
        Alta
    }
}