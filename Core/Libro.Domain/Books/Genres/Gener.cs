using Libro.Domain.Common.Results;
using Libro.Domain.Common.ValueObjects;
using System.Text.RegularExpressions;

namespace Libro.Domain.Books.Genres
{
    public class Gener : ValueObject
    {
        private Gener(string value)
        {
            Value = value;
        }
        public static Result<Gener> Create(string value)
        {
            if (string.IsNullOrEmpty(value))
                return Result<Gener>.Failure(GenerErrors.Empty);

            if (value.Length > GenerConstants.MaxLength)
                return Result<Gener>.Failure(GenerErrors.MaxLength);

            if (value.Length < GenerConstants.MinLength)
                return Result<Gener>.Failure(GenerErrors.MinLength);

            if (!Regex.IsMatch(value, GenerConstants.ValidPattern))
                return Result<Gener>.Failure(GenerErrors.InvalidValue);

            return Result<Gener>.Success(new Gener(value));
        }
        public string Value { get; }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
