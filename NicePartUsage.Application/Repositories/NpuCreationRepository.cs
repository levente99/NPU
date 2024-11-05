using NicePartUsage.Application.Interfaces.Repositories;
using NicePartUsage.Domain.Models;
using NicePartUsage.Infrastructure;

namespace NicePartUsage.Application.Repositories
{
    public class NpuCreationRepository(NicePartUsageDbContext context) : RepositoryBase<NpuCreation>(context), INpuCreationRepository
    {
        // Implement additional methods if needed
    }
}
