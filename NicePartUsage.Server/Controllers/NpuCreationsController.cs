using Microsoft.AspNetCore.Mvc;
using NicePartUsage.Domain.Models;
using NicePartUsage.Application.Interfaces.Services;

namespace NicePartUsage.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NpuCreationController : ControllerBase
    {
        private readonly INpuCreationService _npuCreationService;

        public NpuCreationController(INpuCreationService npuCreationService) => _npuCreationService = npuCreationService;

        // GET: api/NpuCreation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NpuCreation>>> GetNpuCreation([FromQuery(Name = "element")] string? element)
        {
            return await _npuCreationService.GetNpuCreations(element);
        }

        // GET: api/NpuCreation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NpuCreation>> GetNpuCreation(int id)
        {
            var npuCreation = await _npuCreationService.GetNpuCreation(id);

            if (npuCreation == null)
            {
                return NotFound();
            }

            return Ok(npuCreation);
        }

        // PUT: api/NpuCreation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> NpuCreation(int id, NpuCreation npuCreation)
        {
            if (id != npuCreation.Id)
            {
                return BadRequest();
            }

            var updatedNpuCreation = await _npuCreationService.UpdateNpuCreation(id, npuCreation);

            if (updatedNpuCreation == null)
            {
                return NoContent();
            }

            return Ok(updatedNpuCreation);
        }

        // POST: api/NpuCreation
        [HttpPost]
        public async Task<ActionResult<NpuCreation>> AddNpuCreation(NpuCreation npuCreation)
        {
            var newNpuCreation = _npuCreationService.AddNpuCreation(npuCreation);

            return CreatedAtAction("GetNpuCreation", new { id = npuCreation.Id }, newNpuCreation);
        }

        // DELETE: api/NpuCreation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNpuCreation(int id, NpuCreation npuCreation)
        {
            if (id != npuCreation.Id)
            {
                return BadRequest();
            }

            if (await _npuCreationService.DeleteNpuCreation(id, npuCreation))
            {
                return NoContent();
            }

            return Ok();
        }
    }
}
