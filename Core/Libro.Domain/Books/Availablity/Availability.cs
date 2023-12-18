using Libro.Domain.Common.Results;

namespace Libro.Domain.Books.Availablity
{
    public class Availability
    {
        private Availability(bool isAvailable, int availableCopies)
        {
            IsAvailable = isAvailable;
            AvailableCopies = availableCopies;
        }

        public bool IsAvailable { get; private set; }
        public int AvailableCopies { get; private set; }

        public static Result<Availability> Create(int copies)
        {
            if (copies < 0)
                return Result<Availability>.Failure(AvailabilityErrors.NegativeValue);

            if (copies > AvailabalityConstants.MaxNumberOfCopies)
                return Result<Availability>.Failure(AvailabilityErrors.MaxLimit);

            if (copies == 0)
                return Result<Availability>.Success(new Availability(false, copies));

            return Result<Availability>.Success(new Availability(true, copies));
        }
    }
}
