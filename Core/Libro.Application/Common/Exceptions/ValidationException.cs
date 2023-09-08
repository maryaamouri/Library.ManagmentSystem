using FluentValidation.Results;

namespace Libro.Application.Common.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public IList<string> Errors { get; } = new List<string>();
        public ValidationException(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                Errors.Add(error.ErrorMessage);
        }
    }
}
