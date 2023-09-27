using AutoMapper;
using Libro.Application.Transations;
using Libro.Domain.Books;
using Libro.Domain.Transactions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Libro.Application.Borrowing.CancleReservation
{
    public class CancleReservationCommandHandler : IRequestHandler<CancleResarvationCommand, TransactionDto>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CancleReservationCommandHandler(
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

        // 1. check if the transaction Exists
        // ** 2. check if the user is the same patron 
        // 3. check the date, cannot cancle after alrreaady recive
        // 4. change the transaction status to cancled
        public async Task<TransactionDto> Handle(CancleResarvationCommand request, CancellationToken cancellationToken)
        {
            var trans = await _transactionRepository.GetByIdAsync(request.TrasactionId);
            if(trans == null) 
            {
                throw new Exception("Transaction not found");
            }
            if (trans.IsApproved)
                throw new Exception("cannot cancle after already taken");
            trans.IsCanceled = true;
            
            _transactionRepository.UpdateAsync(trans);

            return _mapper.Map<TransactionDto>(trans);
        }
    }
}
