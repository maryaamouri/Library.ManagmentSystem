using AutoMapper;
using Libro.Application.Transations;
using Libro.Domain.Books;
using Libro.Domain.Transactions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Libro.Application.Borrowing.ReturnBook
{
    public class ReturnBookCommandHandler : IRequestHandler<ReturnBookCommand, TransactionDto>
    {
        // 1. check transaction exists
        // 2. check if the book is the same as in the trans
        // 3. return book [change transaction return + make book available]
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReturnBookCommandHandler(
            ITransactionRepository transactionRepository, 
            IMapper mapper, 
            IBookRepository bookRepository, 
            IHttpContextAccessor httpContextAccessor)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _bookRepository = bookRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TransactionDto> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
        {
            var trans = await _transactionRepository.GetByIdAsync(request.TranactionId);
            if (trans == null) {
                throw new Exception("transaction not found.");
            }
            var book = await _bookRepository.GetByIdAsync(request.BookId);
            if (book == null)
            {
                throw new Exception("book not found.");
            }
            if(trans.BookId != request.BookId)
            {
                throw new Exception("Book is not the same been borrowed.");
            }

            book.IsAvailable = true;
            trans.ActualReturnedDate = DateTime.UtcNow;
            await _bookRepository.UpdateAsync(book);
            await _transactionRepository.UpdateAsync(trans);

            return _mapper.Map<TransactionDto>(trans);
        }
    }
}
