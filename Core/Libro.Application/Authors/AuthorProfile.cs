using AutoMapper;
using Libro.Domain.Authors;

namespace Libro.Application.Authors
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorRequest, Author>();
            CreateMap<Author, AuthorDto>();
        }
    }
}
