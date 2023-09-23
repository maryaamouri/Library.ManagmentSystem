using AutoMapper;
using Libro.Application.Borrowing.ReservationService;
using Libro.Domain.Transactions;

namespace Libro.Application.Borrowing.Reservation
{
    internal class ReservationProfile : Profile
    {
        protected ReservationProfile()
        {
            CreateMap<ReservationTransaction,Transaction>();
        }
    }
}
