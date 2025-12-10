using Task2.EntityObjects;

namespace Task2.Interfaces
{
    public interface IApiClient
    {
        Task<SomeEntity> CreateAsync(SomeEntity entity);
        Task DeleteAsync(Guid id);
        Task DeleteManyAsync();
        Task<string?> PrintAsync(Guid id);
        Task<IReadOnlyList<string>> PrintManyAsync();
        Task<SomeEntity?> UpdateAsync(Guid id, SomeEntity entity);
        Task<SomeEntity?> GetOneAsync(Guid id);
        Task<IReadOnlyList<SomeEntity>> GetManyAsync();
        Task<IReadOnlyList<SomeEntity>> GetByFilterAsync(
            string? nameHas = null, 
            string? descriptionHas = null, 
            SomeEntityStatus? statuw = null);
        Task SetStatusAsync(Guid id, SomeEntityStatus status);
        Task ActivateAsync(Guid id);
        Task DeactivateAsync(Guid id);
    }
}
