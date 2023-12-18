using AutoMapper;
using Libro.Application.Transations;
using Libro.Domain.Transactions.TransactionEntity;

namespace Libro.Application.Borrowing.ReturnBook
{
    public class ReturnBookProfile : Profile
    {
        public ReturnBookProfile()
        {
            CreateMap<ReturnBookCommand, Transaction>();
            CreateMap<Transaction, TransactionDto>();
        }
    }
}
