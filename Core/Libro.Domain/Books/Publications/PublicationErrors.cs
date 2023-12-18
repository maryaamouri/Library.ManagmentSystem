using Libro.Domain.Common.Results;

namespace Libro.Domain.Books.Publications
{
    internal static class PublicationErrors
    {
        public static readonly Error InvalidPublicationDate = new (
            "Publication date is invalid.",
            "Publication date is invalid.");

        public static readonly Error PublicationInFuture = new (
            "Publication date cannot be in the future.",
            "publicationDate");

        public static readonly Error PublicationByRequired = new (
            "Publication by is required.",
            "publicationBy");
    }
}
