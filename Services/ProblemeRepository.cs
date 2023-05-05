using InterventionsBackend.Entities;
using Microsoft.EntityFrameworkCore;
using InterventionsBackend.DbContexts;

namespace InterventionsBackend.Services;


public class ProblemeRepository : IProblemeRepository {

    private readonly InterventionsDbContext _context;

    private readonly ILogger<ProblemeRepository> _logger;

    public ProblemeRepository(InterventionsDbContext context, ILogger<ProblemeRepository> logger) {
        this._context = context ??
        throw new ArgumentNullException(nameof(context));

        this._logger = logger??
        throw new ArgumentNullException(nameof(logger));

    }

    public async Task<IEnumerable<TypeProbleme>> GetProblemeAsync()
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