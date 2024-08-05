using FitBox.Models;

namespace FitBox.DTOs
{
    public class MarmitaCreateDto
    {
        public string Nome { get; set; }
        public int TamanhoRecipiente { get; set; }
        public Proteina Proteina { get; set; }
        public Carboidrato Carboidrato { get; set; }
        public bool Verdura { get; set; }
    }
}
