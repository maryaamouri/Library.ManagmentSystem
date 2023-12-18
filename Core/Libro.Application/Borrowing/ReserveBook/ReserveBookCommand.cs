using Libro.Domain.Common.Results;
using MediatR;

namespace Libro.Application.Borrowing.Reservation
{
    public record ReserveBookCommand(Guid BookId) : IRequest<Result<ReserveBookResponse>>;
}
