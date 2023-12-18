using AutoMapper;

namespace Libro.Application.UserProfile
{
    public class UserProfileProfile : Profile
    {
        public UserProfileProfile()
        {
            CreateMap<Domain.UserProfiles.UserProfile, UserProfileDto>();
        }
    }
}
