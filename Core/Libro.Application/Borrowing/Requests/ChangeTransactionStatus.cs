namespace Libro.Application.Borrowing.Requests
{
    public record ChangeTransactionStatus(Guid TransationId,Guid PatronId, string newStatus);
}
