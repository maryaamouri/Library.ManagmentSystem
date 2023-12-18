using AutoMapper;
using Libro.Domain.Books.Entities;

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
