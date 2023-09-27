using AutoMapper;
using Libro.Application.Transations;

namespace Libro.Application.Borrowing.ConfirmReceipt
{
    internal class ConfirmRecieptProfile : Profile
    {
        protected ConfirmRecieptProfile()
        {
            CreateMap<ConfirmReciptCommand,TransactionDto>();
        }
    }
}
