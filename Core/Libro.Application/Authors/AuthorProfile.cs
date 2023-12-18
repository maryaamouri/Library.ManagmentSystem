using AutoMapper;
using Libro.Domain.Authors.AuthorEntity;

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
