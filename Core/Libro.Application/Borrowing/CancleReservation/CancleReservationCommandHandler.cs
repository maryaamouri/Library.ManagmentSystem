using AutoMapper;
using Libro.Application.Common.Exceptions;
using Libro.Application.Identity.Services.UserInfo;
using Libro.Application.Transations;
using Libro.Domain.Books;
using Libro.Domain.BorowingManagers.CancleReservation;
using Libro.Domain.BorowingManagers.Reservation;
using Libro.Domain.Common;
using Libro.Domain.Transactions;
using Libro.Domain.UserProfiles;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Libro.Application.Borrowing.CancleReservation
{
    public class CancleReservationCommandHandler : IRequestHandler<CancleResarvationCommand, CancleReservationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly ICancleReservationManager _cancleReservationManager;
        private readonly ITransactionRepository _transactionRepository;

        public CancleReservationCommandHandler(IMapper mapper, 
            IBookRepository bookRepository,
            IHttpContextAccessor httpContextAccessor,
            ITransactionRepository transactionRepository,
            IUserProfileRepository userProfileRepository,
            IUnitOfWork unitOfWork, IUserService userService, 
            ICancleReservationManager cancleReservationManager)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _httpContextAccessor = httpContextAccessor;
            _userProfileRepository = userProfileRepository;
            _unitOfWork = unitOfWork;
            _transactionRepository = transactionRepository;
            _userService = userService;
            _cancleReservationManager = cancleReservationManager;
        }

        public async Task<CancleReservationResponse> Handle(CancleResarvationCommand request, CancellationToken cancellationToken)
        {
            var patrondata = _httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var patronId = new Guid(patrondata);
            if (patronId == null)
                throw new NotFoundException(typeof(User).Name);

            var patron = _userService.GetUserById(patronId);
            if (patron == null)
                throw new Exception("User Not Found");
            var book = await _bookRepository.GetByIdAsync(request.BookId)
                ?? throw new NotFoundException(typeof(Book).Name, request.BookId);

            var patronProfile = await _userProfileRepository.GetByIdAsync(patronId);

            var trans = await _transactionRepository.GetByIdAsync(request.TrasactionId);
            await _cancleReservationManager.Cancle( book,patronProfile,trans);
            await _unitOfWork.CommitChangesAsync();
            return _mapper.Map<CancleReservationResponse>(trans);
        }
    }
}
