using AutoMapper;
using Libro.Application.Common.Exceptions;
using Libro.Application.Identity.Services.UserInfo;
using Libro.Domain.Books;
using Libro.Domain.BorowingManagers.Reservation;
using Libro.Domain.Common;
using Libro.Domain.UserProfiles;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Libro.Application.Borrowing.Reservation
{
    public class ReserveBookCommandHandler : IRequestHandler<ReserveBookCommand, ReserveBookResponse>
    {
       
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IReserveBookManager _reserveBookManager;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public ReserveBookCommandHandler(
            IMapper mapper,
            IBookRepository bookRepository,
            IHttpContextAccessor httpContextAccessor,
            IReserveBookManager reserveBookManager, 
            IUserProfileRepository userProfileRepository, 
            IUnitOfWork unitOfWork,
            IUserService userService)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _httpContextAccessor = httpContextAccessor;
            _reserveBookManager = reserveBookManager;
            _userProfileRepository = userProfileRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<ReserveBookResponse> Handle(ReserveBookCommand request, CancellationToken cancellationToken)
        {
            var patrondata = _httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var patronId = Guid.Parse(patrondata);
            if(patronId == null)
                throw new NotFoundException(typeof(User).Name);

            var patron = _userService.GetUserById(patronId);
            if (patron == null)
                throw new Exception("User Not Found");

            var book = await _bookRepository.GetByIdAsync(request.BookId)
                ?? throw new NotFoundException(typeof(Book).Name, request.BookId);

            var patronProfile = await _userProfileRepository.GetByIdAsync(patronId);                
            var transaction = await _reserveBookManager.ReserveBook(book, patronProfile);    

            await _unitOfWork.CommitChangesAsync();
            return _mapper.Map<ReserveBookResponse>(transaction);
        }

    }
}
