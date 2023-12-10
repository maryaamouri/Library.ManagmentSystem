using Libro.Application.Common.Absractions;
namespace Libro.Application.Transations
{
    public interface ITransactionService : IService<TransactionRequest,TransactionDto>
    {
    }
}
