using Libro.Identity.Entities;
using Shared.UserProfile;
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
                    UserId = UserSeeder.UserConstants.User1Id
                },
                 new UserProfile
                 {
                     UserProfileId = UserProfileIds.Profile2Id,
                     UserId = UserSeeder.UserConstants.User2Id
                 },
                new UserProfile
                {
                    UserProfileId = UserProfileIds.Profile3Id,
                    UserId = UserSeeder.UserConstants.User3Id
                }
            };

        }
        
    }
}
