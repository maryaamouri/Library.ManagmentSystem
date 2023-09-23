using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libro.Application.Borrowing.ReservationService
{
    internal class ReservationTransaction
    {
        public ReservationTransaction(
            Guid bookId, 
            Guid patronId)
        {
            BookId = bookId;
            PatronId = patronId;
        }

        public Guid TransactionId { set; get; }
        public Guid BookId { get; set; }
        public Guid PatronId { get; set; }

    }
}
