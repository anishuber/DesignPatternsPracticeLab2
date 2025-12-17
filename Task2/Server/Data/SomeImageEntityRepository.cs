using Server.Interfaces;

namespace Server.Data
{
    public class SomeImageEntityRepository : ISomeImageEntityRepository
    {
        private readonly Dictionary<Guid, Uri> _storage = [];

        public Uri? GetImageUrl(Guid id)
        {
            _storage.TryGetValue(id, out var url);
            return url;
        }

        public void SetImageUrl(Guid id, Uri imageUrl)
        {
            _storage[id] = imageUrl;
        }
    }
}
