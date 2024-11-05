using NicePartUsage.Domain.Models;

namespace NicePartUsage.Application.Interfaces.Services
{
    public interface IScoreService
    {
        Task<List<Score>> GetScores();

        Task<Score> GetScore(int id);

        Task<Score> AddScore(Score score);

        Task<Score> UpdateScore(int id, Score score);

        Task<bool> DeleteScore(int id, Score score);
    }
}
