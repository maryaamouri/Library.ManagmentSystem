using AutoMapper;
using Libro.Application.Transations;
using Libro.Domain.Transactions.TransactionEntity;

namespace Libro.Application.Borrowing.ConfirmReceipt
{
    internal class ConfirmRecieptProfile : Profile
    {
        public ConfirmRecieptProfile()
        {
            CreateMap<ConfirmReciptCommand,Transaction>();
            CreateMap<Transaction, TransactionDto>();
        }
    }
}
