using Microsoft.AspNetCore.Mvc;
using Libro.Application.UserProfile;
using Microsoft.AspNetCore.Authorization;

namespace Libro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet("current")]
        [Authorize]
        public async Task<IActionResult> GetCurrentProfile()
        {

                var userProfileDto = await _userProfileService.GetCurrentUserProfile();
                return Ok(userProfileDto);
            
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserProfile(Guid userId)
        {
                var userProfileDto = await _userProfileService.GetUserProfile(userId);
                return Ok(userProfileDto);         
        }
    }
}
