using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Task2.Objects.Entities;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SomeImageEntityController : ControllerBase
    {
        private readonly ISomeImageEntityService _service;

        public SomeImageEntityController(ISomeImageEntityService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("get-image/{id:guid}")]
        public ActionResult<SomeImageEntity> GetImage(Guid id)
        {
            var item = _service.GetImage(id);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost("set-image/{id:guid}")]
        public IActionResult SetImage(Guid id, [FromBody] Uri url)
        {
            if (url is null)
            {
                return BadRequest("No url provided");
            }

            return _service.SetImage(id, url) ? NoContent() : NotFound();
        }

        [HttpGet("get-entities-by-filter")]
        public ActionResult<IEnumerable<SomeImageEntity>> GetEntitiesByFilter(
        [FromQuery] string? nameHas,
        [FromQuery] string? descriptionHas,
        [FromQuery] SomeEntityStatus? status) => Ok(_service.GetEntitiesByFilter(nameHas, descriptionHas, status));
    }
}
