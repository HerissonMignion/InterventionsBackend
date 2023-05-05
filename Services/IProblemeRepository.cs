using InterventionsBackend.Entities;

namespace InterventionsBackend.Services;

public interface IProblemeRepository {
    Task<IEnumerable<TypeProbleme>> GetTypeProblemeAsync();

    Task<Probleme> GetProblemeAsync(int? Id);

    Task<int?> CreateProblemeAsync(Probleme probleme);
    
}