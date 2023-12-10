using AutoMapper;
using Libro.Persistence.DbModels;

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
