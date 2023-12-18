using Libro.Application.Books;
using Libro.Domain.Authors.Repository;
using Libro.Domain.Books.Repositories;
using Libro.Domain.Common.Repositories;
using Libro.Domain.Transactions.Repository;
using Libro.Domain.UserProfiles;
using Libro.Persistence.Repositories;
using Libro.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Libro.Persistence.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddPersistence
        (
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var assembly = Assembly.GetCallingAssembly();

            services.AddDbContext<LiboDbContext>
                (options => options
                .UseSqlServer(configuration.GetConnectionString("DatabaseConnectionString"))
                .EnableSensitiveDataLogging()
              //  );
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
           
            services.AddScoped<IUnitOfWork, UnitOfWork>();
 
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<ISearchFroBookService, SearchForBookService>();

            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            return services;
        }
    }
}
