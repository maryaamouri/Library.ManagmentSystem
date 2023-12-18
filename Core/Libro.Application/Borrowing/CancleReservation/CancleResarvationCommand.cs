using Libro.Domain.Common.Results;
using MediatR;

namespace Libro.Application.Borrowing.CancleReservation
{
    public record CancleResarvationCommand(Guid BookId,Guid TrasactionId) : IRequest<Result<CancleReservationResponse>>;
}
