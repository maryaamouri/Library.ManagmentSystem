using Libro.Domain.Common.Results;

namespace Libro.Domain.Authors.Nationalities
{
    internal class NationalityErrors
    {
            public static readonly Error TooLong = new
                ("Author.Nationality.TooLong",
                "Author Nationality is too long");
            public static readonly Error TooShort = new
                 ("Author.Nationality.TooShort",
                "Nationality is too long");
            public static readonly Error InValidFormat = new
                ("Author.Nationality.InValidFormat",
                "Author Nationality is not in valid format.");
            public static readonly Error Empty = new
                 ("Author.Nationality.Empty",
                "Author Nationality is Empty");
        
    }
}
