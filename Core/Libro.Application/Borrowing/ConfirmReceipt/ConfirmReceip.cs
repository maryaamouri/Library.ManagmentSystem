using AutoMapper;
using Libro.Application.Transations;
using Libro.Domain.Books;
using Libro.Domain.Transactions;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libro.Application.Borrowing.ConfirmReceipt
{
    public class ConfirmReceipCommandHandler : IRequestHandler<ConfirmReciptCommand, TransactionDto>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ConfirmReceipCommandHandler(
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

        public async Task<TransactionDto> Handle(ConfirmReciptCommand request, CancellationToken cancellationToken)
        {
            /*
             * 1. check trans exixts
             * 2. check patron the same as in the trans
             * 3. change trans
             * 4. check if already recived
             * */

            var trans = await _transactionRepository.GetByIdAsync(request.TransationId);
            if(trans == null)
            {
                throw new Exception("transaction not found");
            }

            if(request.PatronId != trans.PatronId)
            {
                throw new Exception("the book is reserved already by another Patron");
            }
            if (trans.IsApproved)
            {
                throw new Exception("book already Receip");
            }
            trans.IsApproved = true;
            await _transactionRepository.UpdateAsync(trans);

            return _mapper.Map<TransactionDto>(trans);
        }
    }
}
