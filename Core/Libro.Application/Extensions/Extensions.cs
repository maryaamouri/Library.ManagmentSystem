using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Libro.Application.Authors;
using Libro.Application.Books;
using Libro.Application.Transations;
using MediatR;
using Libro.Application.Common.PipelineBehaviors;
using Libro.Domain.BorowingManagers.Reservation;
using Libro.Domain.BorowingManagers.CancleReservation;
using Libro.Domain.BorowingManagers.Confirm;
using Libro.Domain.BorowingManagers.ReturnBooks;
using Libro.Application.UserProfile;
using Libro.Domain.Transactions.Factory;

namespace Libro.Application.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ITransactionService, TransationService>();   
            services.AddScoped<IUserProfileService, UserProfileService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            return services;
        }
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<ITransactionFactory, TransactionFactory>();  

            services.AddScoped<IReserveBookManager, ReserveBookManager>();
            services.AddScoped<ICancleReservationManager, CancleReservationManager>();
            services.AddScoped<IConfirmReceiptBookManager, ConfirmReceiptBookManager>();
            services.AddScoped<IReturnBookManager, ReturnBookManager>();

            return services;
        }
        }
}
