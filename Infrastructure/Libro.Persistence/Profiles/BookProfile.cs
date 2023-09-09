using AutoMapper;
using Libro.Domain.Books;

namespace Libro.Persistence.Profiles
{
    public sealed class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, DbModels.Book>()
                .ReverseMap();
        }
    }
}
