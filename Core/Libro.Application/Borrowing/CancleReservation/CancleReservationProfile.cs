using AutoMapper;
using Libro.Application.Borrowing.ConfirmReceipt;
using Libro.Application.Transations;
using System.Transactions;

namespace Libro.Application.Borrowing.CancleReservation
{
    public sealed class CancleReservationProfile : Profile
    {
        public CancleReservationProfile()
        {
            CreateMap<CancleResarvationCommand, Transaction>();
            CreateMap<Transaction, TransactionDto>();
        }
    }
}
