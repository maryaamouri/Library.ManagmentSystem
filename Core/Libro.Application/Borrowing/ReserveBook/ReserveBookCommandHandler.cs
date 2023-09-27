using AutoMapper;
using Libro.Application.Common.Exceptions;
using Libro.Application.Transations;
using Libro.Domain.Books;
using Libro.Domain.Transactions;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Libro.Application.Borrowing.Reservation
{
    public class ReserveBookCommandHandler : IRequestHandler<ReserveBookCommand, TransactionDto>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReserveBookCommandHandler(
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

        public async Task<TransactionDto> Handle(ReserveBookCommand request, CancellationToken cancellationToken)
        {
     
            // 1. check if user exists [patronId]
            // 2. check if book exists [bookId]
            // 3. check if book is available [get book, check IsAvailable]
            // 4. check maximum number of valid books 
            // 5. create transaction
            // 6. make book unavailable
            // 7. add to the user profile

            var patronId = new Guid(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);


            if (patronId == null)
                throw new Exception("User Not Found ");

            var book = await _bookRepository.GetByIdAsync(request.BookId)
                ?? throw new NotFoundException(typeof(Book).Name, request.BookId);

            if (!book.IsAvailable)
                throw new BadRequestException(nameof(book));

            var transaction = new ReserveBookTransaction(book.BookId, patronId);

            var trans = await _transactionRepository.CreateAsync(_mapper.Map<Transaction>(transaction));
            
            return _mapper.Map<TransactionDto>(trans);
        }

    }
}
