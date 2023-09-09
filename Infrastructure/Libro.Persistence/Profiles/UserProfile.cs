using AutoMapper;
namespace Libro.Persistence.Profiles
{
    public sealed class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserProfile, DbModels.UserProfile>()
                .ReverseMap();
        }
    }
}
