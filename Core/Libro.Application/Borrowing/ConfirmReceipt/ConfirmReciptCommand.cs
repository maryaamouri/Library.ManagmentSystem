using Libro.Domain.Common.Results;
using MediatR;

namespace Libro.Application.Borrowing.ConfirmReceipt
{
    public record ConfirmReciptCommand(Guid TransationId, Guid PatronId, Guid bookId) : IRequest<Result<ConfitmRecieptResponse>>;
}
