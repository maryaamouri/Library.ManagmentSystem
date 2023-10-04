using FluentValidation;
using MediatR;

namespace Libro.Application.Common.PipelineBehaviors
{
    public class ValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var validationFailures = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(request, cancellationToken))
                );
            var failures = validationFailures
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .ToList();

            if (failures.Any())
            {
                throw new FluentValidation.ValidationException(failures);
            }

            return await next();

        }
    }
}
