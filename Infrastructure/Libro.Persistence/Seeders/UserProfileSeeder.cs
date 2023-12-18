using Libro.Application.Identity.Services.UserInfo;
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
                new UserProfile{UserId = UserConstants.User1Id },
                new UserProfile{UserId = UserConstants.User2Id }, 
                new UserProfile{ UserId = UserConstants.User3Id } 
            };

            return profiles;
        }
    }
}
