using NicePartUsage.Application.Interfaces.Repositories;
using NicePartUsage.Domain.Models;
using NicePartUsage.Infrastructure;

namespace NicePartUsage.Application.Repositories
{
    public class ElementRepository(NicePartUsageDbContext context) : RepositoryBase<Element>(context), IElementRepository
    {
        // Implement additional methods if needed
    }
}
