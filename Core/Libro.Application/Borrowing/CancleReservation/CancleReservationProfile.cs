using AutoMapper;
using Libro.Application.Borrowing.CancleReservation;
using Libro.Domain.Transactions.TransactionEntity;

namespace Libro.Application.Borrowing.Reservation
{
    internal class CancleReservationProfile : Profile
    {
        public CancleReservationProfile()
        {
            CreateMap<CancleResarvationCommand, Transaction>();
            CreateMap<Transaction, CancleReservationResponse>();
        }
    }
}
