using System.ComponentModel.DataAnnotations;

namespace FitBox.Models
{
    public class Carboidrato
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double Quantidade { get; set; }
        public bool Favorita { get; set; } = false;

    }
}
