using Libro.Domain.Common.Results;
using Libro.Domain.Common.ValueObjects;
using System.Text.RegularExpressions;

namespace Libro.Domain.Books.Titles
{
    public class Title : ValueObject
    {
        private Title(string value)
        {
            Value = value;
        }

        public static Result<Title> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result<Title>.Failure(TitleErrors.Empty);
            }
            if (value.Length > TitleConstants.MaxLength)
            {
                return Result<Title>.Failure(TitleErrors.TooLong);
            }
            if (value.Length < TitleConstants.MinLength)
            {
                return Result<Title>.Failure(TitleErrors.TooShort);
            }
            if (!Regex.IsMatch(value, TitleConstants.ValidPattern))
            {
                return Result<Title>.Failure(TitleErrors.InvalidValue);
            }
            return Result<Title>.Success(new Title(value));
        }
        public string Value { get; }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
