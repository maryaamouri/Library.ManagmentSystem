using AutoMapper;
using Libro.Application.Books;
using Libro.Domain.Books.Entities;

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
