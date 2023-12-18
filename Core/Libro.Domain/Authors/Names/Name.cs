using Libro.Domain.Common.Results;
using Libro.Domain.Common.ValueObjects;
using System.Text.RegularExpressions;

namespace Libro.Domain.Authors.Names
{
    public class Name : ValueObject
    {
        public string Value { get; }
        private Name(string value) 
        { 
            Value = value;
        }
        public static Result<Name> Create(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                return Result<Name>.Failure(NameErrors.Empty);
            }
            if(value.Length>NameConstants.MaxLength)
            {
                return Result<Name>.Failure(NameErrors.TooLong);
            }
            if (value.Length <NameConstants.MinLength)
            {
                return Result<Name>.Failure(NameErrors.TooShort);
            }
            if (Regex.IsMatch(value, NameConstants.Pattern))
            {
                return Result<Name>.Failure(NameErrors.InValidFormat);
            }
            return Result<Name>.Success(new Name(value));
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
