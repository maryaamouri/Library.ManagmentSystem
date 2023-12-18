using Libro.Domain.Common.Results;
using Libro.Domain.Common.ValueObjects;
using System.Text.RegularExpressions;

namespace Libro.Domain.Authors.Nationalities
{
    public class Nationality : ValueObject
    {
        public string Value { get; }
        private Nationality(string value)
        {
            Value = value;
        }
        public static Result<Nationality> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result<Nationality>.Failure(NationalityErrors.Empty);
            }
            if (value.Length > NationalitySettings.MaxLength)
            {
                return Result<Nationality>.Failure(NationalityErrors.TooLong);
            }
            if (value.Length < NationalitySettings.MinLength)
            {
                return Result<Nationality>.Failure(NationalityErrors.TooShort);
            }
            if (Regex.IsMatch(value, NationalitySettings.Pattern))
            {
                return Result<Nationality>.Failure(NationalityErrors.InValidFormat);
            }
            return Result<Nationality>.Success(new Nationality(value));
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
