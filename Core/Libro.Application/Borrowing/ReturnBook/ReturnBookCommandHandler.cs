using AutoMapper;
using Libro.Application.Common.Exceptions;
using Libro.Application.Identity.Services.UserInfo;
using Libro.Application.Transations;
using Libro.Domain.Books;
using Libro.Domain.BorowingManagers.ReturnBooks;
using Libro.Domain.Common;
using Libro.Domain.Transactions;
using Libro.Domain.UserProfiles;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Libro.Application.Borrowing.ReturnBook
{
    public class ReturnBookCommandHandler : IRequestHandler<ReturnBookCommand, ReturnBookResponse>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReturnBookManager _returnBookManager;
        private readonly IUserService _userService;

        public ReturnBookCommandHandler(
            ITransactionRepository transactionRepository,
            IMapper mapper,
            IBookRepository bookRepository, 
            IHttpContextAccessor httpContextAccessor,
            IUnitOfWork unitOfWork,
            IUserService userService)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _bookRepository = bookRepository;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<ReturnBookResponse> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
        {
            var patrondata = _httpContextAccessor.HttpContext.User
               .FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var patronId = new Guid(patrondata);
            if (patronId == null)
                throw new NotFoundException(typeof(User).Name);

            var trans = await _transactionRepository.GetByIdAsync(request.TranactionId);
            if (trans == null) {
                throw new Exception("transaction not found.");
            }
            var patron = _userService.GetUserById(patronId);
            if (patron == null)
                throw new Exception("User Not Found");

            var book = await _bookRepository.GetByIdAsync(request.BookId);
            if (book == null)
            {
                throw new Exception("book not found.");
            }
            if(trans.BookId != request.BookId)
            {
                throw new Exception("Book is not the same been borrowed.");
            }

            var patronProfile = await _userProfileRepository.GetByIdAsync(patronId);
            var transaction = await _returnBookManager.ReturnBook(trans, book, patronProfile);

            await _unitOfWork.CommitChangesAsync();
            return _mapper.Map<ReturnBookResponse>(transaction);
        }
    }
}
