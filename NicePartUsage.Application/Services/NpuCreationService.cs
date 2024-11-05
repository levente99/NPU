using Microsoft.EntityFrameworkCore;
using NicePartUsage.Application.Interfaces;
using NicePartUsage.Application.Interfaces.Repositories;
using NicePartUsage.Application.Interfaces.Services;
using NicePartUsage.Domain.Models;

namespace NicePartUsage.Application.Services
{
    public class NpuCreationService(INpuCreationRepository npuCreationRepository, IUnitOfWork unitOfWork) : INpuCreationService
    {
        private readonly INpuCreationRepository _npuCreationRepository = npuCreationRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<NpuCreation> AddNpuCreation(NpuCreation npuCreation)
        {
            await _npuCreationRepository.AddAsync(npuCreation);
            await _unitOfWork.SaveChangesAsync();

            return npuCreation;
        }

        public async Task<NpuCreation> GetNpuCreation(int id)
        {
            return await _npuCreationRepository.GetByIdAsync(id);
        }

        public async Task<List<NpuCreation>> GetNpuCreations(string elementName)
        {
            var npuCreations = _npuCreationRepository.GetAll()
                .Include(x => x.Elements)
                .Include(x => x.Scores)
                .Include(x => x.Creator)
                .AsQueryable();

            return await npuCreations.Where(npu => string.IsNullOrWhiteSpace(elementName) || npu.Elements.Any(e => e.Name.ToLower().Contains(elementName.ToLower()))).ToListAsync();
        }

        public async Task<NpuCreation> UpdateNpuCreation(int id, NpuCreation npuCreation)
        {
            var entity = await _npuCreationRepository.GetByIdAsync(id);

            if (entity == null)
                return null;
           
            _npuCreationRepository.Update(npuCreation);

            await _unitOfWork.SaveChangesAsync();

            return npuCreation;
        }

        public async Task<bool> DeleteNpuCreation(int id, NpuCreation npuCreation)
        {
            var entity = await _npuCreationRepository.GetByIdAsync(id);

            if (entity == null)
                return false;

            _npuCreationRepository.Delete(npuCreation);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
