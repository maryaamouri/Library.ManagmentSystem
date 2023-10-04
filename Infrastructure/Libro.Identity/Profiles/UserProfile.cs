using AutoMapper;
using Libro.Application.Identity.Services.UserInfo;
using Libro.Identity.Entities;

namespace Libro.Identity.Profiles
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, User>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        }
    }
}