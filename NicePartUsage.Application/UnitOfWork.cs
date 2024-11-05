using Microsoft.EntityFrameworkCore;
using NicePartUsage.Application.Interfaces;
using NicePartUsage.Infrastructure;

namespace NicePartUsage.Application
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NicePartUsageDbContext _context;
        private bool _disposed = false;

        public UnitOfWork(NicePartUsageDbContext context) => _context = context;
        public DbContext Context => _context;

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
