using AutoMapper;
using Libro.Domain.UserProfiles;

namespace Libro.Persistence.Repositories
{
    public sealed class UserProfileRepository : GenericRepository<UserProfile, DbModels.UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(LiboDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
