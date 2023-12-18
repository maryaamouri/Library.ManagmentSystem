namespace Libro.Domain.Common.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IList<TEntity>> GetAsync();
        Task SaveChangesAsync();
    }
}
