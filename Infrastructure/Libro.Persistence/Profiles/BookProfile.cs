using AutoMapper;
using Libro.Application.Books;
using Libro.Domain.Books;

namespace Libro.Persistence.Profiles
{
    public sealed class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, DbModels.Book>()
                .ReverseMap();
            CreateMap< DbModels.Book,BookDto>();
        }
    }
}
