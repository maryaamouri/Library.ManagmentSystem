using AutoMapper;
using Libro.Application.Transations;

namespace Libro.Application.Borrowing.CancleReservation
{
    internal sealed class CancleReservationProfile : Profile
    {
        protected CancleReservationProfile()
        {
            CreateMap<CancleResarvationCommand,TransactionDto>();
        }
    }
}
