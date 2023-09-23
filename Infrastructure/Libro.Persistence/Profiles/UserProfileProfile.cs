using AutoMapper;
using Libro.Infrastructure.Shared.UserProfiles;
namespace Libro.Persistence.Profiles
{
    public sealed class UserProfileProfile : Profile
    {
        public UserProfileProfile()
        {
            CreateMap<UserProfile, Domain.UserProfiles.UserProfile>()
                .ReverseMap();
        }
    }
}
