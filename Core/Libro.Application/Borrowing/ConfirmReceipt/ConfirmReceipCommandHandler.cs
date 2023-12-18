using AutoMapper;
using Libro.Application.Identity.Services.UserInfo;
using Libro.Domain.BorowingManagers.Confirm;
using Libro.Domain.Common.Repositories;
using Libro.Domain.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Libro.Application.Borrowing.ConfirmReceipt
{
    public class ConfirmReceipCommandHandler : IRequestHandler<ConfirmReciptCommand, Result<ConfitmRecieptResponse>>
    {
       
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IConfirmReceiptBookManager _confirmReceiptBookManager;

        public ConfirmReceipCommandHandler(
            IMapper mapper, 
            IHttpContextAccessor httpContextAccessor, 
            IUnitOfWork unitOfWork, 
            IUserService userService,
            IConfirmReceiptBookManager confirmReceiptBookManager)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _confirmReceiptBookManager = confirmReceiptBookManager;
        }

        public async Task<Result<ConfitmRecieptResponse>> Handle(ConfirmReciptCommand request, CancellationToken cancellationToken)
        {
            var trans = await _unitOfWork.TransactionRepository.GetByIdAsync(request.TransationId);
            if(trans == null)
            {
                return Result<ConfitmRecieptResponse>.Failure(new Error("transaction not found",""));
            }

            if (request.PatronId != trans.PatronId)
            {
                return Result<ConfitmRecieptResponse>.Failure(new Error("the book is reserved already by another Patron",""));
            }

            var librariandata = _httpContextAccessor.HttpContext.User
               .FindFirst("UserId")?.Value;

            if (!Guid.TryParse(librariandata, out Guid librarianId))
            {
                return Result<ConfitmRecieptResponse>.Failure(new Error("User Not Found", ""));
            }

            var librarian = await _userService.GetUserById(librarianId);
            if(librarian == null)
            {
                return Result<ConfitmRecieptResponse>.Failure(new Error("User Not Found.", ""));
            }
            var librarianProfile = await _unitOfWork.UserProfileRepository.GetByIdAsync(librarianId);
            if (librarianProfile is null)
            {
                return Result<ConfitmRecieptResponse>.Failure(new Error("User Profile Not Found.", ""));
            }
            var book = await _unitOfWork.BookRepository.GetByIdAsync(request.bookId);
            var domainResult = _confirmReceiptBookManager.Confirm(book, trans,librarianProfile);
            if (domainResult.IsFailure)
                return Result<ConfitmRecieptResponse>.Failure(domainResult.Error);

            await _unitOfWork.TransactionRepository.UpdateAsync(trans);
            await _unitOfWork.CommitChangesAsync();
            return Result<ConfitmRecieptResponse>.Success(_mapper.Map<ConfitmRecieptResponse>(trans));
        }
    }
}
