using Microsoft.EntityFrameworkCore;
using NicePartUsage.Application.Interfaces;
using NicePartUsage.Application.Interfaces.Repositories;
using NicePartUsage.Application.Interfaces.Services;
using NicePartUsage.Domain.Models;

namespace NicePartUsage.Application.Services
{
    public class ScoreService(IScoreRepository scoreRepository, IUnitOfWork unitOfWork) : IScoreService
    {
        private readonly IScoreRepository _scoreRepository = scoreRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Score> AddScore(Score score)
        {
            await _scoreRepository.AddAsync(score);
            await _unitOfWork.SaveChangesAsync();

            return score;
        }

        public async Task<Score> GetScore(int id)
        {
            return await _scoreRepository.GetByIdAsync(id);
        }

        public async Task<List<Score>> GetScores()
        {
            return await _scoreRepository.GetAll().ToListAsync();
        }

        public async Task<Score> UpdateScore(int id, Score score)
        {
            var entity = await _scoreRepository.GetByIdAsync(id);

            if (entity == null)
                return null;
           
            _scoreRepository.Update(score);

            await _unitOfWork.SaveChangesAsync();

            return score;
        }

        public async Task<bool> DeleteScore(int id, Score score)
        {
            var entity = await _scoreRepository.GetByIdAsync(id);

            if (entity == null)
                return false;

            _scoreRepository.Delete(score);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
