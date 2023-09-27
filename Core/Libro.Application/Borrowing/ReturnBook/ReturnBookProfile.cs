using AutoMapper;
using Libro.Application.Transations;

namespace Libro.Application.Borrowing.ReturnBook
{
    internal class ReturnBookProfile : Profile
    {
        protected ReturnBookProfile()
        {
            CreateMap<ReturnBookCommand, TransactionDto>();
        }
    }
}
