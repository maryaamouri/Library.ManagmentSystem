using AutoMapper;
using Libro.Domain.Authors;

namespace Libro.Persistence.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, DbModels.Author>()
                .ReverseMap();
        }
    }
}
