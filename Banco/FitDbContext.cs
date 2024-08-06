using System.Linq;
using System.Threading.Tasks;
using FitBox.Models;
using Microsoft.EntityFrameworkCore;

public class FitDbContext : DbContext
{
    public FitDbContext(DbContextOptions<FitDbContext> options) : base(options) { }

    public DbSet<Marmita> Marmitas { get; set; }
    public DbSet<Ingrediente> Ingredientes { get; set; }
    public DbSet<Receitas> Receitas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Marmita>()
            .HasOne(m => m.Proteina)
            .WithMany()
            .HasForeignKey(m => m.ProteinaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Marmita>()
            .HasOne(m => m.Carboidrato)
            .WithMany()
            .HasForeignKey(m => m.CarboidratoId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public async Task RemoveDuplicateIngredientesAsync()
    {
        // Transforma os nomes dos ingredientes em minúsculas e remove duplicatas
        var ingredientes = await Ingredientes.ToListAsync();
        var ingredientesLowerCase = ingredientes
            .GroupBy(i => i.Nome.ToLower())
            .Select(g => g.First())
            .ToList();

        // Remove todos os ingredientes da tabela
        Ingredientes.RemoveRange(ingredientes);

        // Adiciona novamente os ingredientes únicos
        Ingredientes.AddRange(ingredientesLowerCase);

        // Salva as alterações no banco de dados
        await SaveChangesAsync();
    }
}
