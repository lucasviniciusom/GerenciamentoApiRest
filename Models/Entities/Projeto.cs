using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gerenciamentoapirest.Models
{

    [Table("Projeto")]
    public class Projeto: BaseEntity
    {
        
       
        [Required]
        public string Nome { get; set; } // Nome do Projeto

        [Required]
        public string Descricao { get; set; } // Descrição do projeto

        [Required]
        public DateTime DataInicio { get; set; } // Data de inicio do projeto

        public DateTime? DataFim { get; set; } // Data final do projeto

        public StatusProjeto Status { get; set; }

        // Relacionamento com a classe Tarefa
        public ICollection<Tarefa> Tarefas { get; set; }

    }

    public enum StatusProjeto
    {
        Não_iniciada,
        Em_andamento,
        Finalizada
    }
}
