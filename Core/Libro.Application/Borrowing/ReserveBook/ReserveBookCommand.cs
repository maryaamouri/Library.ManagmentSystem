using MediatR;

namespace Libro.Application.Borrowing.Reservation
{
    public record ReserveBookCommand(Guid BookId) : IRequest<ReserveBookResponse>;
}
