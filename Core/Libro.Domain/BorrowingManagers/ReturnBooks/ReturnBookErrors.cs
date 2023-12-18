using Libro.Domain.Common.Results;
using System.Diagnostics;

namespace Libro.Domain.BorowingManagers.ReturnBooks
{
    internal static class ReturnBookErrors
    {

        public static readonly Error TransactionBookMismatch = new 
        (
            "TRANSACTION_BOOK_MISMATCH",
            "The transaction does not match the specified book. Unable to return the book. Book is not the same been borrowed."
        );
    }
}
