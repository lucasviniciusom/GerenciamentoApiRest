using System.ComponentModel.DataAnnotations;

namespace gerenciamentoapirest.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}