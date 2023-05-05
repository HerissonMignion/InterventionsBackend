using InterventionsBackend.Entities;
using Microsoft.EntityFrameworkCore;
using InterventionsBackend.DbContexts;

namespace InterventionsBackend.Services;


public class TypesProblemeRepository : ITypesProblemeRepository {

    private readonly InterventionsDbContext _context;

    private readonly ILogger<TypesProblemeRepository> _logger;

    public TypesProblemeRepository(InterventionsDbContext context, ILogger<TypesProblemeRepository> logger) {
        this._context = context ??
        throw new ArgumentNullException(nameof(context));

        this._logger = logger??
        throw new ArgumentNullException(nameof(logger));

    }

    public async Task<IEnumerable<TypeProbleme>> GetTypesProblemeAsync()
    {
        try {
            return await _context.TypeProbleme.OrderBy(o => o.Name).ToListAsync();
        }
        catch (Exception ex) {
            this._logger.LogError($"Erreur dans l'obtention des données de la base de données {ex}");
        }
        return null;
    }
}