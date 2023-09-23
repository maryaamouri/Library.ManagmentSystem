using Libro.Infrastructure.Shared.UserProfiles;

namespace Libro.Identity.Seeders
{
    internal static class UserProfielSeeder
    {
        public static UserProfile[] Seed()
        {
            return new UserProfile[]
            {
                new UserProfile
                {
                    UserProfileId = UserProfileIds.Profile1Id,
                   
                },
                 new UserProfile
                 {
                     UserProfileId = UserProfileIds.Profile2Id,
                     
                 },
                new UserProfile
                {
                    UserProfileId = UserProfileIds.Profile3Id,
                   
                }
            };

        }
        
    }
}
