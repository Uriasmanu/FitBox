using FitBox.Models;

namespace FitBox.DTOs
{
    public class MarmitaCreateDto
    {
        public string Nome { get; set; }
        public int TamanhoRecipiente { get; set; } = 500;
        public Proteina Proteina { get; set; }
        public Carboidrato Carboidrato { get; set; }
        public bool Verdura { get; set; }
        public bool Favorita { get; set; } = false;


    }
}
