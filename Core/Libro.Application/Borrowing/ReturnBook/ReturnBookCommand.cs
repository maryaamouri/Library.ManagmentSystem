using Libro.Application.Transations;
using MediatR;

namespace Libro.Application.Borrowing.ReturnBook
{
    public record ReturnBookCommand(Guid TranactionId, Guid BookId) : IRequest<TransactionDto>;
}
