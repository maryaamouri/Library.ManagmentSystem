using AutoMapper;
using Libro.Domain.Transactions;

namespace Libro.Persistence.Profiles
{
    public sealed class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, DbModels.Transaction>()
                .ReverseMap();
        }
    }
}
