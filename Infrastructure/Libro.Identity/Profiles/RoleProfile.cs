using AutoMapper;
using Libro.Application.Identity.Services.UserInfo;
using Microsoft.AspNetCore.Identity;

namespace Libro.Identity.Profiles
{
    internal class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<IdentityRole<Guid>, Role>()
              .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id))
              .ReverseMap();
        }
    }
}
