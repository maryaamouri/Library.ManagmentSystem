using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Libro.Application.Authors;
using Libro.Application.Books;

namespace Libro.Application.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            //services.Scan(b => b.FromAssemblies(assembly)
            //    .AddClasses(c => c.AssignableTo(typeof(IService<,>)))
            //    .AsImplementedInterfaces()
            //    .WithSingletonLifetime());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<IAuthorService, AuthorService>();

            services.AddAutoMapper(typeof(AuthorProfile));
            services.AddAutoMapper(typeof(BookProfile));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
