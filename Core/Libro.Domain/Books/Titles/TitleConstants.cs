namespace Libro.Domain.Books.Titles
{
    internal static class TitleConstants
    {
        public static int MaxLength { get; } = 50;
        public static int MinLength { get; } = 3;
        public static readonly string ValidPattern = @"^[a-zA-Z\s\p{L}\u0600-\u06FF.!?-]+$";
    }
}
