using Libro.Domain.Common.Results;

namespace Libro.Domain.Authors.Periods
{
    internal static class PeriodErrors
    {
        public readonly static Error EmptyBirthOfDate = new ("Period.BirthOfDate.Empty", "Date of birth is empty.");
        public readonly static Error InvalidDateOfBirth = new("Period.InvalidDateOfBirth", "Date of birth cannot be in the future.");
        public readonly static Error InvalidDateOfDeth = new("Period.InvalidDateOfDeth", "Date of death cannot be before the date of birth.");

    }
}
