using System.ComponentModel.DataAnnotations;

namespace FitBox.Models
{
    public class Proteina
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double Quantidade { get; set; }
    }
}
