namespace Libro.Domain.Common.Results
{
    public class Result<TValue> : Result
    {
        private readonly TValue _value;
  
        protected internal Result(TValue? value, bool isSuccess, Error error)
             : base(isSuccess, error) => _value = value;
        public TValue Value => IsSuccess
            ? _value :
            throw new InvalidOperationException("The value of the faliure result cannot be accessed.");

        public static implicit operator Result<TValue>(TValue value)
            => new(value, true, Error.None);
        public static Result<TValue> Success(TValue value) => new(value, true, Error.None);
        public static Result<TValue> Failure(Error error) => new(default, false, error);

    }
}
