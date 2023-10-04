using AutoMapper;
using Libro.Application.Transations;

namespace Libro.Application.Borrowing.ReturnBook
{
    public class ReturnBookProfile : Profile
    {
        public ReturnBookProfile()
        {
            CreateMap<ReturnBookCommand, Domain.Transactions.Transaction>();
            CreateMap<Domain.Transactions.Transaction, TransactionDto>();
        }
    }
}
