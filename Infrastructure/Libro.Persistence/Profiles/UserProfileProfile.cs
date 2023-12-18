using AutoMapper;
using Libro.Persistence.DbModels;

namespace Libro.Persistence.Profiles
{
    public sealed class UserProfileProfile : Profile
    {
        public UserProfileProfile()
        {
            CreateMap<Domain.UserProfiles.UserProfile, UserProfile>()
                .ForMember(dest => dest.Transactions, opt => opt.MapFrom(src =>
                    src.Transactions)); // AutoMapper will handle the mapping of Transactions.

            CreateMap<UserProfile, Domain.UserProfiles.UserProfile>()
                .ForMember(dest => dest.Transactions, opt => opt.MapFrom(src =>
                    src.Transactions)); // Reverse mapping.

            CreateMap<Domain.UserProfiles.UserProfile, UserProfile>()
                .ForMember(dest => dest.CurrentlyBorrowdBooks, opt => opt.MapFrom(src =>
                    src.CurrentlyBorrowdBooks)); // AutoMapper will handle the mapping of Transactions.

            CreateMap<UserProfile, Domain.UserProfiles.UserProfile>()
                .ForMember(dest => dest.CurrentlyBorrowdBooks, opt => opt.MapFrom(src =>
                    src.CurrentlyBorrowdBooks)); // Reverse mapping.
        }
    }
}
