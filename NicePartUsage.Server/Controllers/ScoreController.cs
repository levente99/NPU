using Microsoft.AspNetCore.Mvc;
using NicePartUsage.Domain.Models;
using NicePartUsage.Application.Interfaces.Services;

namespace NicePartUsage.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreService _scoreService;

        public ScoreController(IScoreService scoreService) => _scoreService = scoreService;

        // GET: api/Score
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> GetScore()
        {
            return await _scoreService.GetScores();
        }

        // GET: api/Score/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Score>> GetScore(int id)
        {
            var score = await _scoreService.GetScore(id);

            if (score == null)
            {
                return NotFound();
            }

            return Ok(score);
        }

        // PUT: api/Score/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Score(int id, Score score)
        {
            if (id != score.Id)
            {
                return BadRequest();
            }

            var updatedScore = await _scoreService.UpdateScore(id, score);

            if (updatedScore == null)
            {
                return NoContent();
            }

            return Ok(updatedScore);
        }

        // POST: api/Score
        [HttpPost]
        public async Task<ActionResult<Score>> AddScore(Score score)
        {
            var newScore = _scoreService.AddScore(score);

            return CreatedAtAction("GetScore", new { id = score.Id }, newScore);
        }

        // DELETE: api/Score/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScore(int id, Score score)
        {
            if (await _scoreService.DeleteScore(id, score))
            {
                return NoContent();
            }

            return Ok();

        }
    }
}
