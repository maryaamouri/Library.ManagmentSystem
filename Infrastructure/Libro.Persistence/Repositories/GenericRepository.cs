using AutoMapper;
using Libro.Domain.Common;
using Microsoft.EntityFrameworkCore;


namespace Libro.Persistence.Repositories
{
    public class GenericRepository<TEntity, TDbModel> : IRepository<TEntity>
        where TEntity : class
        where TDbModel : class
    {
        private readonly LiboDbContext _dbContext;
        private readonly IMapper _mapper;

        public GenericRepository(LiboDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var dbModel = _mapper.Map<TDbModel>(entity);

            await _dbContext.AddAsync(dbModel);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TEntity>(dbModel);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            var dbModel = _mapper.Map<TDbModel>(entity);

            _dbContext.Set<TDbModel>().Remove(dbModel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> GetAsync()
        {
            var dbModels = await _dbContext.Set<TDbModel>().ToListAsync();
            var domainModels = _mapper.Map<IList<TEntity>>(dbModels);
            return domainModels;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var dbModel = await _dbContext.Set<TDbModel>().FindAsync(id);
            return _mapper.Map<TEntity>(dbModel);
        }


        public async Task UpdateAsync(TEntity entity)
        {
            var dbModel = _mapper.Map<TDbModel>(entity);

            _dbContext.Entry(dbModel).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

    }
}
