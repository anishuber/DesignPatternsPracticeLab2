using Task2.Interfaces;

namespace Task2.Data
{
    public class SomeImageEntityRepository : ISomeImageEntityRepository
    {
        private readonly Dictionary<Guid, Uri> _storage = [];

        public Task<Uri?> GetImageUrlAsync(Guid id)
        {
            _storage.TryGetValue(id, out var url);
            return Task.FromResult(url);
        }

        public Task SetImageUrlAsync(Guid id, Uri imageUrl)
        {
            _storage[id] = imageUrl;
            return Task.CompletedTask;
        }
    }
}
