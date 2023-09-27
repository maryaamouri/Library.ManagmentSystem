using Libro.Application.Transations;
using MediatR;

namespace Libro.Application.Borrowing.CancleReservation
{
    public record CancleResarvationCommand(Guid TrasactionId) : IRequest<TransactionDto>;
}
