
using InterventionsBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterventionsBackend.DbContexts;


public class InterventionsDbContext : DbContext
{

    public DbSet<TypeProbleme> TypeProbleme { get; set; } = null!;

    public DbSet<Probleme> Probleme { get; set; } = null!;

    public InterventionsDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        this.Seed(modelBuilder);
        base.OnModelCreating(modelBuilder);

    }

    private void Seed(ModelBuilder modelBuilder) {
        modelBuilder.Entity<TypeProbleme>().HasData(
            new TypeProbleme { Id = 1, Name = "Problème d'écran" },
            new TypeProbleme { Id = 2, Name = "Problème avec le disque dur" },
            new TypeProbleme { Id = 3, Name = "Problème de connexion réseau" },
            new TypeProbleme { Id = 4, Name = "Problème avec la souris" },
            new TypeProbleme { Id = 5, Name = "Problème de clavier" },
            new TypeProbleme { Id = 6, Name = "Problème d'ouverture du logiciel Ms-Word" },
            new TypeProbleme { Id = 7, Name = "Problème d'ouverture du logiciel Ms-Excel" },
            new TypeProbleme { Id = 8, Name = "Problème d'imprimante" },
            new TypeProbleme { Id = 9, Name = "Problème entre la chaise et le clavier..." },
            new TypeProbleme { Id = 10, Name = "Autre" }
        );
    }

}












