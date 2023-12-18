namespace Libro.Domain.Configurations
{
    public static class BorrowingConfigurations
    {
        public static int MaximumNumberOfBooks { get; set; } = 10;
        public static int MinimumNumberOfAllowedOverDue { get; set; } = 10;
        public static int DueToDays { get; set; } = 7;
    }
}
