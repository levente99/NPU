namespace NicePartUsage.Application.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> GetAll();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task SaveAsync();
    }
}
