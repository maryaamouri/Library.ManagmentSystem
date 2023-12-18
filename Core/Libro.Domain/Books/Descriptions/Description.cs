using Libro.Domain.Common.Results;
using Libro.Domain.Common.ValueObjects;
using System.Text.RegularExpressions;

namespace Libro.Domain.Books.Descriptions
{
    public class Description : ValueObject
    {
        private Description(string value)
        {
            Value = value;
        }

        public static Result<Description> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result<Description>.Failure(DescriptionErrors.Empty);
            }
            if (value.Length > DescriptionConstants.MaxLength)
            {
                return Result<Description>.Failure(DescriptionErrors.TooLong);
            }
            if (value.Length < DescriptionConstants.MinLength)
            {
                return Result<Description>.Failure(DescriptionErrors.TooShort);
            }
            if (!Regex.IsMatch(value, DescriptionConstants.ValidPattern))
            {
                return Result<Description>.Failure(DescriptionErrors.InvalidValue);
            }
            return Result<Description>.Success(new Description(value));
        }
        public string Value { get; }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}

