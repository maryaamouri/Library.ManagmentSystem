namespace Libro.Domain.Books.Genres
{
    public static class GenerConstants
    {
        public static int MaxLength { get; } = 100;
        public static int MinLength { get; } = 3;
        public static readonly string ValidPattern = @"^[a-zA-Z\s\p{L}\u0600-\u06FF.!?-]+$";
    }
}
