using Libro.Domain.Common.Results;
using Libro.Domain.Common.ValueObjects;
using System.Text.RegularExpressions;

namespace Libro.Domain.Authors.Descriptions
{
    public class Description : ValueObject
    {
        public string Value { get; }
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
            if (value.Length > DescriptionSettings.MaxLength)
            {
                return Result<Description>.Failure(DescriptionErrors.TooLong);
            }
            if (value.Length < DescriptionSettings.MinLength)
            {
                return Result<Description>.Failure(DescriptionErrors.TooShort);
            }
            if (Regex.IsMatch(value, DescriptionSettings.Pattern))
            {
                return Result<Description>.Failure(DescriptionErrors.InValidFormat);
            }
            return Result<Description>.Success(new Description(value));
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
