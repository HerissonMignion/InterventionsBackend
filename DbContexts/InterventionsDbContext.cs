
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

}












