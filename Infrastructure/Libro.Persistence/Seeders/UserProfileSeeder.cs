using Libro.Infrastructure.Shared.UserProfiles;
using Libro.Persistence.DbModels;

namespace Libro.Persistence.Seeders
{
    internal static class UserProfileSeeder
    {
        internal static UserProfile[] Seed()
        {
            var profiles = new UserProfile[]
            {
                new UserProfile(UserConstants.User1Id),
                new UserProfile(UserConstants.User2Id), 
                new UserProfile(UserConstants.User3Id) 
            };

            return profiles;
        }
    }
}
