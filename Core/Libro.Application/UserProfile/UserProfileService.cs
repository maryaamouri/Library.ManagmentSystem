using AutoMapper;
using Libro.Application.Common.Exceptions;
using Libro.Application.Identity.Services.UserInfo;
using Libro.Domain.UserProfiles;
using Microsoft.AspNetCore.Http;

namespace Libro.Application.UserProfile
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public UserProfileService(
            IUserProfileRepository userProfileRepository,
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _userProfileRepository = userProfileRepository;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<UserProfileDto> GetCurrentUserProfile()
        {
            var userId = _contextAccessor.HttpContext.User
                .FindFirst("UserId")?.Value;

            if (!Guid.TryParse(userId, out Guid profileId))
            {
                throw new NotFoundException(typeof(User).Name);
            }
            var profile = await _userProfileRepository.GetByIdAsync(profileId);
            return _mapper.Map<UserProfileDto>(profile);
        }

        public async Task<UserProfileDto> GetUserProfile(Guid userId)
        {
            var profile = await _userProfileRepository.GetByIdAsync(userId);
            if(profile == null)
                throw new NotFoundException(typeof(User).Name);
            return _mapper.Map<UserProfileDto>(profile);    
        }
    }
}
