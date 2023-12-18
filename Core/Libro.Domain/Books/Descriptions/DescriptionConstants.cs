namespace Libro.Domain.Books.Descriptions
{
    internal class DescriptionConstants
    {
        public static readonly int MaxLength = 1000;
        public static readonly int MinLength = 20;
        public static readonly string ValidPattern = @"^[a-zA-Z0-9\s\d\p{L}\u0600-\u06FF.!?-]+$";
    }
}
