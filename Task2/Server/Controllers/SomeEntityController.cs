using Microsoft.AspNetCore.Mvc;
using Task2.Objects.Entities;
using Server.Interfaces;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SomeEntityController : ControllerBase
    {
        private readonly ISomeEntityRepository _repository;
        public SomeEntityController(ISomeEntityRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost("create")]
        public ActionResult<SomeEntity> Create([FromBody] SomeEntity entity)
        {
            var created = _repository.Create(entity);
            return CreatedAtAction(nameof(GetOne), new { id = created.Id }, created);
        }

        [HttpPut("update/{id:guid}")]
        public ActionResult<SomeEntity> Update(Guid id, [FromBody] SomeEntity entity)
        {
            entity.Id = id;
            var updated = _repository.Update(entity);
            return updated is null ? NotFound() : Ok(updated);
        }

        [HttpGet("get-one/{id:guid}")]
        public ActionResult<SomeEntity> GetOne(Guid id)
        {
            var entity = _repository.GetOne(id);
            return entity is null ? NotFound() : Ok(entity);
        }

        [HttpGet("get-many")]
        public ActionResult<IEnumerable<SomeEntity>> GetMany()
        {
            var items = _repository.GetMany();
            return Ok(items);
        }

        [HttpGet("get-by-filter")]
        public ActionResult<IEnumerable<SomeEntity>> GetByFilter(
        [FromQuery] string? nameHas,
        [FromQuery] string? descriptionHas,
        [FromQuery] SomeEntityStatus? status)
        {
            IEnumerable<SomeEntity> result = _repository.GetByFilter(e =>
                (nameHas == null || e.Name.Contains(nameHas, StringComparison.OrdinalIgnoreCase)) &&
                (descriptionHas == null || e.Description.Contains(descriptionHas, StringComparison.OrdinalIgnoreCase)) &&
                (status == null || e.Status == status));

            return Ok(result);
        }

        [HttpDelete("delete/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _repository.Delete(id);
            return NoContent();
        }

        [HttpPost("delete-many")]
        public IActionResult DeleteMany()
        {
            _repository.DeleteMany();
            return NoContent();
        }

        [HttpGet("print/{id:guid}")]
        public ActionResult<string> Print(Guid id)
        {
            var entity = _repository.GetOne(id);
            return entity is null ? NotFound() : Ok($"[{entity.Id}] {entity.Name} ({entity.Status}) - {entity.Description}");
        }

        [HttpGet("print-many")]
        public ActionResult<IEnumerable<string>> PrintMany()
        {
            var result = _repository.GetMany().Select(entity => $"[{entity.Id}] {entity.Name} ({entity.Status}) - {entity.Description}");
            return Ok(result);
        }

        [HttpPost("set-status/{id:guid}")]
        public IActionResult SetStatus(Guid id, [FromBody] SomeEntityStatus status)
        {
            _repository.SetStatus(id, status);
            return NoContent();
        }

        [HttpPost("deactivate/{id:guid}")]
        public IActionResult Deactivate(Guid id)
        {
            _repository.SetStatus(id, SomeEntityStatus.Disabled);
            return NoContent();
        }

        [HttpPost("activate/{id:guid}")]
        public IActionResult Activate(Guid id)
        {
            _repository.SetStatus(id, SomeEntityStatus.Enabled);
            return NoContent();
        }
    }
}
