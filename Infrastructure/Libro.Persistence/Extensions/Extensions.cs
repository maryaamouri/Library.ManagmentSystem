﻿using Libro.Application.Books;
using Libro.Domain.Authors;
using Libro.Domain.Books;
using Libro.Domain.Common;
using Libro.Domain.Transactions;
using Libro.Domain.UserProfiles;
using Libro.Persistence.Profiles;
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
                .UseSqlServer(configuration.GetConnectionString("DatabaseConnectionString")));
               // .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));


            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<ISearchFroBookService, SearchForBookService>();

            services.AddAutoMapper(typeof(AuthorProfile));
            services.AddAutoMapper(typeof(BookProfile));
            services.AddAutoMapper(typeof(UserProfileProfile));
            services.AddAutoMapper(typeof(TransactionProfile));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            return services;
        }
    }
}
