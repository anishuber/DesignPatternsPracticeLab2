using Microsoft.AspNetCore.Mvc;
using Task2.EntityObjects;
using Task2.Interfaces;

namespace Task2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SomeImageEntityController : ControllerBase
    {
        private readonly ISomeEntityRepository _entities;
        private readonly ISomeImageEntityRepository _imageRepository;

        public SomeImageEntityController(ISomeEntityRepository entities, ISomeImageEntityRepository imageRepository)
        {
            _entities = entities ?? throw new ArgumentNullException(nameof(entities));
            _imageRepository = imageRepository ?? throw new ArgumentNullException(nameof(imageRepository));
        }

        [HttpGet("get-image/{id:guid}")]
        public async Task<ActionResult<SomeImageEntity>> GetImage(Guid id)
        {
            var entity = _entities.GetOne(id);
            if (entity is null)
            {
                return NotFound();
            }

            var imageUrl = await _imageRepository.GetImageUrlAsync(id);

            return new SomeImageEntity
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Status = entity.Status,
                ImageUrl = imageUrl
            };
        }

        [HttpPost("set-image/{id:guid}")]
        public async Task<ActionResult> SetImage(Guid id, [FromBody] Uri imageUrl)
        {
            var entity = _entities.GetOne(id);
            if (entity is null)
            {
                return NotFound();
            }

            await _imageRepository.SetImageUrlAsync(id, imageUrl);
            return NoContent();
        }

        [HttpGet("get-entities-by-filter")]
        public async Task<ActionResult<IEnumerable<SomeImageEntity>>> GetEntitiesByFilter(
        [FromQuery] string? nameHas,
        [FromQuery] string? descriptionHas,
        [FromQuery] SomeEntityStatus? status)
        {
            var entities = _entities.GetByFilter(e =>
                (nameHas == null || e.Name.Contains(nameHas, StringComparison.OrdinalIgnoreCase)) &&
                (descriptionHas == null || e.Description.Contains(descriptionHas, StringComparison.OrdinalIgnoreCase)) &&
                (!status.HasValue || e.Status == status.Value));

            var result = new List<SomeImageEntity>();

            foreach (var entity in entities)
            {
                var imageUrl = await _imageRepository.GetImageUrlAsync(entity.Id);
                result.Add(new SomeImageEntity
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    Status = entity.Status,
                    ImageUrl = imageUrl
                });
            }

            return result;
        }
    }
}
