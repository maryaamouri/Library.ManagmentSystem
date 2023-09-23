using Libro.Domain.Authors;
using Libro.Domain.Books;
using Libro.Domain.Transactions;
using Libro.Persistence.Profiles;
using Libro.Persistence.Repositories;
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
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            //services.Scan(b => b.FromAssemblies(assembly)
            //     .AddClasses(c => c.AssignableTo(typeof(IRepository<>)))
            //     .AsImplementedInterfaces()
            //     .WithSingletonLifetime());

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            services.AddAutoMapper(typeof(AuthorProfile));
            services.AddAutoMapper(typeof(BookProfile));
            services.AddAutoMapper(typeof(UserProfileProfile));
            services.AddAutoMapper(typeof(TransactionProfile));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
