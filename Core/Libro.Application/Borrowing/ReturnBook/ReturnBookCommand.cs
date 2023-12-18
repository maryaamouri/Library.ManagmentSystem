using Libro.Domain.Common.Results;
using MediatR;

namespace Libro.Application.Borrowing.ReturnBook
{
    public record ReturnBookCommand(Guid TranactionId, Guid BookId, Guid PatronId) : IRequest<Result<ReturnBookResponse>>;
}
