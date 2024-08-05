using System;
using System.ComponentModel.DataAnnotations;

namespace FitBox.Models
{
    public class Ingrediente
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double Quantidade { get; set; }
        public TipoIngrediente Tipo { get; set; }
        public bool Favorita { get; set; } = false;

    }

    public enum TipoIngrediente
    {
        Proteina,
        Carboidrato
    }
}
