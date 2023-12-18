using AutoMapper;
using Libro.Domain.Transactions.TransactionEntity;

namespace Libro.Application.Transations
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction,TransactionDto>();
            CreateMap<TransactionRequest, Transaction>();
        }
    }
}
