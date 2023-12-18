using AutoMapper;
using Libro.Application.Identity.Services.UserInfo;
using Libro.Domain.BorowingManagers.Reservation;
using Libro.Domain.Common.Repositories;
using Libro.Domain.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Libro.Application.Borrowing.Reservation
{
    public class ReserveBookCommandHandler : IRequestHandler<ReserveBookCommand, Result<ReserveBookResponse>>
    {
       
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IReserveBookManager _reserveBookManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public ReserveBookCommandHandler(
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IReserveBookManager reserveBookManager,
            IUnitOfWork unitOfWork,
            IUserService userService)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _reserveBookManager = reserveBookManager;
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ReserveBookResponse>> Handle(ReserveBookCommand request, CancellationToken cancellationToken)
        {
            var patrondata = _httpContextAccessor.HttpContext.User
                .FindFirst("UserId")?.Value;

            if (!Guid.TryParse(patrondata, out Guid patronId))
            {
                return Result<ReserveBookResponse>.Failure(new Error("Invalid patron data", "Invalid patron data"));
            }

            var patron = _userService.GetUserById(patronId);

            if (patron == null)
            {
                return Result<ReserveBookResponse>.Failure(new Error("User Not Found", "User Not Found"));
            }

            var book = await _unitOfWork.BookRepository.GetByIdAsync(request.BookId);

            if (book == null)
            {
                return Result<ReserveBookResponse>.Failure(new Error( $"Book with ID {request.BookId} not found.","Book Not Found"));
            }

            var patronProfile = await _unitOfWork.UserProfileRepository.GetByIdAsync(patronId);

            var domainResult = _reserveBookManager.ReserveBook(book, patronProfile);
            Console.WriteLine(domainResult.IsSuccess);
            Console.WriteLine(domainResult.Error.Code);
            if (domainResult.IsSuccess)
            {
                var response = _mapper.Map<ReserveBookResponse>(domainResult.Value);
                await _unitOfWork.BookRepository.UpdateAsync(book);
                await _unitOfWork.UserProfileRepository.UpdateAsync(patronProfile);
                await _unitOfWork.TransactionRepository.CreateAsync(domainResult.Value);
                await _unitOfWork.CommitChangesAsync();
                return Result<ReserveBookResponse>.Success(response);
            }
            else
            {
                return Result<ReserveBookResponse>.Failure(domainResult.Error);
            }
        }


    }
}
