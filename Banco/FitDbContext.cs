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
}
