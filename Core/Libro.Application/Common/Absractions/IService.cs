namespace Libro.Application.Common.Absractions
{
    public interface IService<TRequest, TResponce>
    {
        Task<TResponce> CreateAsync(TRequest t);
        Task<TResponce> GetByIdAsync(Guid id);
        Task<IList<TResponce>> GetListAsync();
        Task<TResponce> UpdateAsync(Guid id, TRequest t);
        Task DeleteAsync(Guid id);
    }
}
