using FitBox.Models;

namespace FitBox.DTOs
{
    public class IngredienteDTO
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }
        public bool Favorita {  get; set; } = false;
        public TipoIngrediente Tipo { get; set; }
    }
}
