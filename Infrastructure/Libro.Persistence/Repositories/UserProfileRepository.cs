using AutoMapper;
using Libro.Domain.UserProfiles;
using Microsoft.EntityFrameworkCore;

namespace Libro.Persistence.Repositories
{
    public sealed class UserProfileRepository : IUserProfileRepository
    {
        private readonly IMapper _mapper;
        private readonly LiboDbContext _dbContext;

        public UserProfileRepository(LiboDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserProfile> CreateAsync(UserProfile userProfile)
        {
            var dbUserProfile = _mapper.Map<UserProfile, DbModels.UserProfile>(userProfile);
            await _dbContext.UserProfile.AddAsync(dbUserProfile);
            return _mapper.Map<UserProfile>(dbUserProfile);
        }

        public async Task UpdateAsync(UserProfile userProfile)
        {
            var dbUserProfile = _mapper.Map<UserProfile, DbModels.UserProfile>(userProfile);
            _dbContext.Entry(dbUserProfile).State = EntityState.Modified;
        }

        public async Task<UserProfile> GetByIdAsync(Guid id)
        {
            var dbUserProfile = await _dbContext.UserProfile
                .FirstOrDefaultAsync(u => u.UserId == id);
            return _mapper.Map<UserProfile>(dbUserProfile);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
