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

        public int TamanhoRecipiente { get; internal set; }
        public Guid ProteinaId { get; internal set; }
        public Guid CarboidratoId { get; internal set; }
        public Ingrediente Proteina { get; set; }
        public Ingrediente Carboidrato { get; set; }
        public bool Verdura { get; internal set; }
        public DateTime DataCriacao { get; internal set; }
        public bool Favorita { get; set; } = false;
    }
}
