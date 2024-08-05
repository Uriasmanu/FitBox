using System;
using System.ComponentModel.DataAnnotations;

namespace FitBox.Models
{
    public class MarmitaIngrediente
    {
        [Key]
        public Guid Id { get; set; }
        public Guid MarmitaId { get; set; }
        public Marmita Marmita { get; set; }
        public Guid IngredienteId { get; set; }
        public Ingrediente Ingrediente { get; set; }
        public double Quantidade { get; set; }
    }
}
