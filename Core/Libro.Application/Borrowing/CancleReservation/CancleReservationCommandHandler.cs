using AutoMapper;
using Libro.Application.Borrowing.Reservation;
using Libro.Application.Identity.Services.UserInfo;
using Libro.Domain.BorowingManagers.CancleReservation;
using Libro.Domain.Common.Repositories;
using Libro.Domain.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Libro.Application.Borrowing.CancleReservation
{
    public class CancleReservationCommandHandler : IRequestHandler<CancleResarvationCommand, Result<CancleReservationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly ICancleReservationManager _cancleReservationManager;

        public CancleReservationCommandHandler(IMapper mapper, 
            IHttpContextAccessor httpContextAccessor,
            IUnitOfWork unitOfWork, IUserService userService, 
            ICancleReservationManager cancleReservationManager)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _cancleReservationManager = cancleReservationManager;
        }

        public async Task<Result<CancleReservationResponse>> Handle(CancleResarvationCommand request, CancellationToken cancellationToken)
        {
            var patrondata = _httpContextAccessor.HttpContext.User
                .FindFirst("UserId")?.Value;

            if (!Guid.TryParse(patrondata, out Guid patronId))
            {
                return Result<CancleReservationResponse>.Failure(new Error("Invalid patron data", "Patron Not Found"));
            }

            var patron = _userService.GetUserById(patronId);
            if (patron is null)
                return Result<CancleReservationResponse>.Failure(new Error("Invalid patron data", "Patron Not Found"));

            var book = await _unitOfWork.BookRepository.GetByIdAsync(request.BookId);
            if(book is null)
                 return Result<CancleReservationResponse>.Failure(new Error("Invalid patron data", "Book Not Found"));

            var patronProfile = await _unitOfWork.UserProfileRepository.GetByIdAsync(patronId);

            var trans = await _unitOfWork.TransactionRepository.GetByIdAsync(request.TrasactionId);
            if (trans is null)
                return Result<CancleReservationResponse>.Failure(new Error("Trasaction Not Found","Not Found"));
             
            var domainResult = _cancleReservationManager.Cancle( book,patronProfile,trans);

            if (domainResult.IsSuccess)
            {
                var response = _mapper.Map<CancleReservationResponse>(domainResult.Value);
                await _unitOfWork.BookRepository.UpdateAsync(book);
                await _unitOfWork.UserProfileRepository.UpdateAsync(patronProfile);
                await _unitOfWork.TransactionRepository.UpdateAsync(domainResult.Value);
                await _unitOfWork.CommitChangesAsync();
                return Result<CancleReservationResponse>.Success(response);
            }
            else
            {
                return Result<CancleReservationResponse>.Failure(domainResult.Error);
            }
        }
    }
}
