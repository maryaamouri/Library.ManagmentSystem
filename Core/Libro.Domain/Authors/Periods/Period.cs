using Libro.Domain.Common.Results;
using Libro.Domain.Common.ValueObjects;

namespace Libro.Domain.Authors.Periods
{
    public class Period : ValueObject
    {
        public DateOnly DateOfBirth { get; }
        public DateOnly? DateOfDeath { get; }
        public int Age { get; }

        private Period(DateOnly dateOfBirth, DateOnly? dateOfDeath)
        {
            DateOfBirth = dateOfBirth;
            DateOfDeath = dateOfDeath;
            Age = CalculateAge(dateOfBirth,dateOfDeath);
        }

        public static Result<Period> Create(DateOnly dateOfBirth, DateOnly? dateOfDeath)
        {
            //if (dateOfBirth == null)
            //{
            //    return Result<Period>.Failure(PeriodErrors.EmptyBirthOfDate);
            //}

            if (dateOfBirth > DateOnly.FromDateTime(DateTime.UtcNow))
            {
                return Result<Period>.Failure(PeriodErrors.InvalidDateOfBirth);
            }

            if (dateOfDeath.HasValue && dateOfDeath <= dateOfBirth)
            {
                return Result<Period>.Failure(PeriodErrors.InvalidDateOfDeth);
            }

            var period = new Period(dateOfBirth, dateOfDeath);
            return Result<Period>.Success(period);
        }
        private static int CalculateAge(DateOnly dateOfBirth, DateOnly? dateOfDeath)
        {
            int age;
            if (dateOfDeath != null)
                age = dateOfDeath.Value.Year - dateOfBirth.Year;
            else
            age = DateTime.UtcNow.Year - dateOfBirth.Year;  
                
            return age;
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return DateOfBirth;
            if(DateOfDeath is not null)
                yield return DateOfDeath;
        }
    }
}
