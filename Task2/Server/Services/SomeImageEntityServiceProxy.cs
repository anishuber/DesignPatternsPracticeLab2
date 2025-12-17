using Server.Interfaces;
using System.Reflection;
using Task2.Objects.Entities;

namespace Server.Services
{
    public class SomeImageEntityServiceProxy : ISomeImageEntityService
    {
        private readonly ISomeImageEntityService _service;

        public SomeImageEntityServiceProxy(ISomeImageEntityService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public SomeImageEntity? GetImage(Guid id) => _service.GetImage(id);
        public bool SetImage(Guid id, Uri imageUrl) => _service.SetImage(id, imageUrl);
        public IEnumerable<SomeImageEntity> GetEntitiesByFilter(
           string? nameHas = null,
           string? descriptionHas = null,
           SomeEntityStatus? status = null) => _service.GetEntitiesByFilter(nameHas, descriptionHas, status);

    }
}
