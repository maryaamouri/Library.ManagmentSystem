using AutoMapper;
using Libro.Application.Identity.Services.UserInfo;
using Libro.Domain.BorowingManagers.ReturnBooks;
using Libro.Domain.Common.Repositories;
using Libro.Domain.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Libro.Application.Borrowing.ReturnBook
{
    public class ReturnBookCommandHandler : IRequestHandler<ReturnBookCommand, Result<ReturnBookResponse>>
    {      
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReturnBookManager _returnBookManager;
        private readonly IUserService _userService;

        public ReturnBookCommandHandler(
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IUnitOfWork unitOfWork,
            IReturnBookManager returnBookManager,
            IUserService userService)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _returnBookManager = returnBookManager;
            _userService = userService;
        }

        public async Task<Result<ReturnBookResponse>> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
        {
            // Get Lib Id
            var libraiandata = _httpContextAccessor.HttpContext.User
                .FindFirst("UserId")?.Value;

            if (!Guid.TryParse(libraiandata, out Guid LibrarianId))
            {
                return Result<ReturnBookResponse>.Failure(new Error("INNVALID Token Data", "Invalid data Librarian Not Found"));
            }
            var librarian = _userService.GetUserById(LibrarianId);
            if (librarian == null)
                return Result<ReturnBookResponse>.Failure(new Error("Librarian Not Found.", "Invalid patron data"));


            // Validate Transaction Id
            var trans = await _unitOfWork.TransactionRepository.GetByIdAsync(request.TranactionId);
            if (trans == null) {
                return Result<ReturnBookResponse>.Failure(new Error("transaction not found.", "Invalid patron data"));
            }
            // Check Book Exixts
            var book = await _unitOfWork.BookRepository.GetByIdAsync(request.BookId);
            if (book == null)
            {
                return Result<ReturnBookResponse>.Failure(new Error("book not found.", "Invalid patron data"));
            }
            // Check Patronm Profile

            var patronProfile = await _unitOfWork.UserProfileRepository.GetByIdAsync(request.PatronId);
            if (patronProfile == null)
            {
                return Result<ReturnBookResponse>.Failure(new Error("Patron not found.", "Invalid patron data"));
            }

            var domainResult = _returnBookManager.ReturnBook(trans, book, patronProfile, LibrarianId);

            Console.WriteLine(domainResult.IsSuccess);
            Console.WriteLine(domainResult.Error.Code);
            if (domainResult.IsSuccess)
            {
                var response = _mapper.Map<ReturnBookResponse>(domainResult.Value);
                await _unitOfWork.BookRepository.UpdateAsync(book);
                await _unitOfWork.UserProfileRepository.UpdateAsync(patronProfile);
                await _unitOfWork.TransactionRepository.UpdateAsync(domainResult.Value);
                await _unitOfWork.CommitChangesAsync();
                return Result<ReturnBookResponse>.Success(response);
            }
            else
            {
                return Result<ReturnBookResponse>.Failure(domainResult.Error);
            }
        }
    }
}
