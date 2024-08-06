public class ReceitaDTO
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public int TamanhoRecipiente { get; set; }
    public string Proteina { get; set; }
    public string Carboidrato { get; set; }
    public bool Verdura { get; set; }
    public DateTime DataCriacao { get; set; }
    public bool Favorita { get; set; } = false;
}
