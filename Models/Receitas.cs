using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitBox.Models
{
    public class Receitas
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public List<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();
    }
}
