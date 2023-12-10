using AutoMapper;
using Libro.Application.Transations;
using Libro.Domain.Transactions;

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
