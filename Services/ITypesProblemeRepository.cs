using InterventionsBackend.Entities;

namespace InterventionsBackend.Services;

public interface ITypesProblemeRepository {
    Task<IEnumerable<TypeProbleme>> GetTypesProblemeAsync();
    
}