using Server.Interfaces;
using Task2.Objects.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace Server.Services
{
    public class SomeImageEntityService : ISomeImageEntityService
    {
        private readonly ISomeEntityRepository _entityRepository;
        private readonly ISomeImageEntityRepository _imageRepository;

        public SomeImageEntityService(ISomeEntityRepository entities, ISomeImageEntityRepository images)
        {
            _entityRepository = entities ?? throw new ArgumentNullException(nameof(entities));
            _imageRepository = images ?? throw new ArgumentNullException(nameof(images));
        }

        public SomeImageEntity? GetImage(Guid id)
        {
            var entity = _entityRepository.GetOne(id);

            if (entity is null)
            {
                return null;
            }

            var url = _imageRepository.GetImageUrl(id);
            return ConvertToImageEntity(entity, url);
        }

        public bool SetImage(Guid id, Uri imageUrl)
        {
            ArgumentNullException.ThrowIfNull(imageUrl);

            var entity = _entityRepository.GetOne(id);
            if (entity is null)
            {
                return false;
            }

            _imageRepository.SetImageUrl(id, imageUrl);
            return true;
        }

        public IEnumerable<SomeImageEntity> GetEntitiesByFilter(
            string? nameHas = null,
            string? descriptionHas = null,
            SomeEntityStatus? status = null)
        {
            var entities = _entityRepository.GetByFilter(e =>
                (nameHas == null || e.Name.Contains(nameHas, StringComparison.OrdinalIgnoreCase)) &&
                (descriptionHas == null || e.Description.Contains(descriptionHas, StringComparison.OrdinalIgnoreCase)) &&
                (status == null || e.Status == status));

            return entities.Select(e => ConvertToImageEntity(e, _imageRepository.GetImageUrl(e.Id)));
        }

        private static SomeImageEntity ConvertToImageEntity(SomeEntity entity, Uri? url)
        {
            return new SomeImageEntity
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Status = entity.Status,
                ImageUrl = url,
            };
        }
    }
}
