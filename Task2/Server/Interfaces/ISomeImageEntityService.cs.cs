using Task2.Objects.Entities;

namespace Server.Interfaces
{
    public interface ISomeImageEntityService
    {
        SomeImageEntity? GetImage(Guid id);
        bool SetImage(Guid id, Uri imageUrl);

        IEnumerable<SomeImageEntity> GetEntitiesByFilter(
            string? nameHas = null,
            string? descriptionHas = null,
            SomeEntityStatus? status = null);
    }
}
