namespace Libro.Application.UserProfile
{
    public interface IUserProfileService
    {
        public Task<UserProfileDto> GetUserProfile(Guid userId);
        public Task<UserProfileDto> GetCurrentUserProfile();
    }
}
