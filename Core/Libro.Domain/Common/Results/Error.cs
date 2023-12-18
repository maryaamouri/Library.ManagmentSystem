namespace Libro.Domain.Common.Results
{
    public class Error : IEquatable<Error>
    {
        public static readonly Error None = new(string.Empty,string.Empty);
        public string Code { get; }
        public string Message { get; }

        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public static implicit operator string(Error error) => error.Code;

        public override bool Equals(object obj)
        {
            if (obj is Error otherError)
            {
                return Code == otherError.Code && Message == otherError.Message;
            }
            return false;
        }

        public bool Equals(Error other)
        {
            if (other is null)
            {
                return false;
            }
            return Code == other.Code && Message == other.Message;
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode() ^ Message.GetHashCode();
        }

        public static bool operator ==(Error a, Error b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }
            if (a is null || b is null)
            {
                return false;
            }
            return a.Equals(b);
        }

        public static bool operator !=(Error a, Error b)
        {
            return !(a == b);
        }
    }
}
