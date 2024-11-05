using Microsoft.AspNetCore.Mvc;
using NicePartUsage.Domain.Models;
using NicePartUsage.Application.Interfaces.Services;

namespace NicePartUsage.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElementController : ControllerBase
    {
        private readonly IElementService _elementService;

        public ElementController(IElementService elementService) => _elementService = elementService;

        // GET: api/Element
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Element>>> GetElement()
        {
            return await _elementService.GetElements();
        }

        // GET: api/Element/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Element>> GetElement(int id)
        {
            var element = await _elementService.GetElement(id);

            if (element == null)
            {
                return NotFound();
            }

            return Ok(element);
        }

        // PUT: api/Element/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Element(int id, Element element)
        {
            if (id != element.Id)
            {
                return BadRequest();
            }

            var updatedElement = await _elementService.UpdateElement(id, element);

            if (updatedElement == null)
            {
                return NoContent();
            }

            return Ok(updatedElement);
        }

        // POST: api/Element
        [HttpPost]
        public async Task<ActionResult<Element>> AddElement(Element element)
        {
            var newElement = _elementService.AddElement(element);

            return CreatedAtAction("GetElement", new { id = element.Id }, newElement);
        }

        // DELETE: api/Element/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElement(int id, Element element)
        {
            if (await _elementService.DeleteElement(id, element))
            {
                return NoContent();
            }

            return Ok();
        }
    }
}
