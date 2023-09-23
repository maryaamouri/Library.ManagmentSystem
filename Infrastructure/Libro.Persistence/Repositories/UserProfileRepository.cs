using AutoMapper;
using Libro.Infrastructure.Shared.UserProfiles;
namespace Libro.Persistence.Repositories
{
    public sealed class UserProfileRepository : GenericRepository<Domain.UserProfiles.UserProfile, UserProfile>, Domain.UserProfiles.IUserProfileRepository
    {
        public UserProfileRepository(LiboDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
