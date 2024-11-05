using NicePartUsage.Application.Interfaces.Repositories;
using NicePartUsage.Domain.Models;
using NicePartUsage.Infrastructure;

namespace NicePartUsage.Application.Repositories
{
    public class ScoreRepository(NicePartUsageDbContext context) : RepositoryBase<Score>(context), IScoreRepository
    {
        // Implement additional methods if needed
    }
}
