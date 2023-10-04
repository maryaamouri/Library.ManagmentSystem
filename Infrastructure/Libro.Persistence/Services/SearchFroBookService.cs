using AutoMapper;
using Libro.Application.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace Libro.Persistence.Services
{
    internal class SearchForBookService : ISearchFroBookService
    {
        private readonly LiboDbContext _dbContext;
        private readonly IMapper _mapper;

        public SearchForBookService(LiboDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IList<BookDto>> SearchByAuthor(Guid AuthorId)
        {
            string sqlQuery = "SELECT * FROM Library.Books WHERE AuthorId = {0}";

            var books = await _dbContext.Books
                .FromSqlRaw(sqlQuery, AuthorId)
                .ToListAsync();
            return _mapper.Map<IList<BookDto>>(books);
        }

        public async Task<IList<BookDto>> SearchByGenre(string genre)
        {
            string sqlQuery = "SELECT * FROM Library.Books WHERE Genre = {0}";

            var books = await _dbContext.Books
                .FromSqlRaw(sqlQuery, genre)
                .ToListAsync();

            return _mapper.Map<IList<BookDto>>(books);
        }

        public async Task<IList<BookDto>> SearchByPublishDate(DateTime dateTime)
        {
            string sqlQuery = "SELECT * FROM Library.Books WHERE PublicationDate = {0}";

            var books = await _dbContext.Books
                .FromSqlRaw(sqlQuery, dateTime)
                .ToListAsync();

            return _mapper.Map<IList<BookDto>>(books);
        }

        public async Task<IList<BookDto>> SearchByTitle(string title)
        {
            string sqlQuery = "SELECT * FROM Library.Books WHERE Title = {0}";

            var books = await _dbContext.Books
                .FromSqlRaw(sqlQuery, title)
                .ToListAsync();

            return _mapper.Map<IList<BookDto>>(books);
        }
    }
}
