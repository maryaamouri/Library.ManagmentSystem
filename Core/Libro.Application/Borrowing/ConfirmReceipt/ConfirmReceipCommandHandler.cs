using AutoMapper;
using Libro.Application.Identity.Services.UserInfo;
using Libro.Application.Transations;
using Libro.Domain.Books;
using Libro.Domain.BorowingManagers.Confirm;
using Libro.Domain.Common;
using Libro.Domain.Transactions;
using Libro.Domain.UserProfiles;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Libro.Application.Borrowing.ConfirmReceipt
{
    public class ConfirmReceipCommandHandler : IRequestHandler<ConfirmReciptCommand, ConfitmRecieptResponse>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IConfirmReceiptBookManager _confirmReceiptBookManager;
        private readonly IBookRepository _bookRepository;

        public ConfirmReceipCommandHandler(ITransactionRepository transactionRepository, 
            IMapper mapper, 
            IHttpContextAccessor httpContextAccessor, 
            IUserProfileRepository userProfileRepository,
            IUnitOfWork unitOfWork, 
            IUserService userService,
            IBookRepository bookRepository,
            IConfirmReceiptBookManager confirmReceiptBookManager)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userProfileRepository = userProfileRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _bookRepository = bookRepository;
            _confirmReceiptBookManager = confirmReceiptBookManager;
        }

        public async Task<ConfitmRecieptResponse> Handle(ConfirmReciptCommand request, CancellationToken cancellationToken)
        {
            var trans = await _transactionRepository.GetByIdAsync(request.TransationId);
            if(trans == null)
            {
                throw new Exception("transaction not found");
            }

            if(request.PatronId != trans.PatronId)
            {
                throw new Exception("the book is reserved already by another Patron");
            }
            var librarianId = new Guid(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var librarian = await _userService.GetUserById(librarianId);
            if(librarian == null)
            {
                throw new Exception("User not Found.");
            }
            var librarianProfile = await _userProfileRepository.GetByIdAsync(librarianId);
            var book = await _bookRepository.GetByIdAsync(request.bookId);
            await _confirmReceiptBookManager.Confirm(book, trans,librarianProfile);
            await _transactionRepository.UpdateAsync(trans);
            await _unitOfWork.CommitChangesAsync();
            return _mapper.Map<ConfitmRecieptResponse>(trans);
        }
    }
}
