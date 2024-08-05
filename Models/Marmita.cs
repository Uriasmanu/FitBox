using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitBox.Models
{
    public class Marmita
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double TamanhoRecipiente { get; set; }
        public Guid ProteinaId { get; set; }
        public Guid CarboidratoId { get; set; }
        public Ingrediente Proteina { get; set; }
        public Ingrediente Carboidrato { get; set; }
        public bool Verdura { get; set; }
        public bool Favorita { get; set; } = false;
        public bool Consumo { get; set; } = false;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime? DataConsumo { get; set; }

        public ICollection<MarmitaIngrediente> MarmitasIngredientes { get; set; } = new List<MarmitaIngrediente>();
    }
}
