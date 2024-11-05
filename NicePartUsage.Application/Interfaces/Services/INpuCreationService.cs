using NicePartUsage.Domain.Models;

namespace NicePartUsage.Application.Interfaces.Services
{
    public interface INpuCreationService
    {
        Task<List<NpuCreation>> GetNpuCreations(string element = "");

        Task<NpuCreation> GetNpuCreation(int id);

        Task<NpuCreation> AddNpuCreation(NpuCreation npuCreation);

        Task<NpuCreation> UpdateNpuCreation(int id, NpuCreation npuCreation);

        Task<bool> DeleteNpuCreation(int id, NpuCreation npuCreation);
    }
}
