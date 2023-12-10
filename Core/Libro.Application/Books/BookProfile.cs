using AutoMapper;
using Libro.Domain.Books;

namespace Libro.Application.Books
{
    internal class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookRequest, Book>();
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
