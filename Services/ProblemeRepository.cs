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

    public async Task<IEnumerable<TypeProbleme>> GetTypeProblemeAsync()
    {
        try {
            return await _context.TypeProbleme.OrderBy(o => o.descriptionTypeProbleme).ToListAsync();
        }
        catch (Exception ex) {
            this._logger.LogError($"Erreur dans l'obtention des données de la base de données {ex}");
        }
        return null;
    }

    public async Task<Probleme> GetProblemeAsync(int? Id) {
        try {
            return await _context.Probleme.Include(tbl => tbl.TypeProbleme).FirstOrDefaultAsync(champs => champs.Id == Id);
        }
        catch (Exception ex) {
            this._logger.LogError($"Erreur dans l'obtention des données de la base de données {ex}");
        }
        return null;
    }


    public async Task<int?> CreateProblemeAsync(Probleme probleme)
    {
        try
        {
            var infos = await _context.Probleme.AddAsync(probleme);
            if (infos.State == EntityState.Added) {
                var resultat = await SaveAsync();

                if (resultat) {
                    return probleme.Id;
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erreur dans l'ajout des données de la base de données : {ex}");
        }
        return null;
    }

    
    public async Task<bool> SaveAsync()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
}