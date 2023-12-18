namespace Libro.Domain.Common.Results
{
    public class Result
    {
        public readonly Error Error;

        public readonly bool IsSuccess;
        public bool IsFailure => !IsSuccess;
        protected internal Result(bool IsSuccess, Error error)
        {
            if (IsSuccess && error != Error.None)
                throw new InvalidOperationException("Result Object can be either in success state or failed state not both.");
            if(IsSuccess==false && error == Error.None)
                throw new InvalidOperationException("Result Object can be either in success state or failed state not both.");
            Error = error;
            this.IsSuccess = IsSuccess;
        }
        public static Result Success() => new(true, Error.None);
        public static Result Failure(Error error) => new(false, error);
    }
}
