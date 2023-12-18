using AutoMapper;
using Libro.Domain.Transactions.TransactionEntity;

namespace Libro.Application.Borrowing.Reservation
{
    internal class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<ReserveBookTransaction, Transaction>();
            CreateMap<Transaction, ReserveBookResponse>();
        }
    }
}
