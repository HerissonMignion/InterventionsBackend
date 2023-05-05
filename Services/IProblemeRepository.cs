using InterventionsBackend.Entities;

namespace InterventionsBackend.Services;

public interface IProblemeRepository {
    Task<IEnumerable<TypeProbleme>> GetProblemeAsync();
    
}