namespace Libro.Domain.UserProfiles
{
    public interface IUserProfileRepository 
    {
        Task<UserProfile> CreateAsync(UserProfile userProfile);
        Task UpdateAsync(UserProfile userProfile);
        Task<UserProfile> GetByIdAsync(Guid id);
    }
}
