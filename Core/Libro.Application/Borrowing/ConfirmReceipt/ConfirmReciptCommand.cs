using Libro.Application.Transations;
using MediatR;

namespace Libro.Application.Borrowing.ConfirmReceipt
{
    public record ConfirmReciptCommand(Guid TransationId, Guid PatronId) : IRequest<TransactionDto>;
}
