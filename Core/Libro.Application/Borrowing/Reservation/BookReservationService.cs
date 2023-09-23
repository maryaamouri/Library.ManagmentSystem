using AutoMapper;
using Libro.Application.Common.Exceptions;
using Libro.Application.Transations;
using Libro.Domain.Books;
using Libro.Domain.Transactions;
using Libro.Domain.UserProfiles;


namespace Libro.Application.Borrowing.ReservationService
{
    public class BookReservationService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _profileRepository;
        private readonly IBookRepository _bookRepository;// check availability
        public async Task<TransactionDto> Reserve(ReserveBookRequest request)
        {
            throw new NotImplementedException();
            // 1. validate token
            // 2. check if book exists
            // 3. check maximum number of valid books
            // 4. create transaction
            // 5. make book unavailable
            // 6. add to the user profile
            var book = await _bookRepository.GetByIdAsync(request.BookId)
                ?? throw new NotFoundException(typeof(Book).Name, request.BookId);

            if(!book.IsAvailable)
                throw new BadRequestException(nameof(book));

           


           // var transaction = new ReservationTransaction(book.BookId, patronId);
         //   return _mapper.Map<TransactionDto>(transaction);
        }

    }
}
