using Libro.Application.Books;
using Microsoft.AspNetCore.Mvc;

namespace Libro.Api.Controllers
{
        [Route("api/books")]
        [ApiController]
        public class BookSearchController : ControllerBase
        {
            private readonly ISearchFroBookService _searchService;

            public BookSearchController(ISearchFroBookService searchService)
            {
                _searchService = searchService;
            }

            [HttpGet("by-author/{authorId}")]
            public async Task<ActionResult<IList<BookDto>>> SearchByAuthor(Guid authorId)
            {
                var books = await _searchService.SearchByAuthor(authorId);
                return Ok(books);
            }

            [HttpGet("by-genre/{genre}")]
            public async Task<ActionResult<IList<BookDto>>> SearchByGenre(string genre)
            {
                var books = await _searchService.SearchByGenre(genre);
                return Ok(books);
            }

            [HttpGet("by-publish-date/{dateTime}")]
            public async Task<ActionResult<IList<BookDto>>> SearchByPublishDate(DateTime dateTime)
            {
                var books = await _searchService.SearchByPublishDate(dateTime);
                return Ok(books);
            }

            [HttpGet("by-title/{title}")]
            public async Task<ActionResult<IList<BookDto>>> SearchByTitle(string title)
            {
                var books = await _searchService.SearchByTitle(title);
                return Ok(books);
            }
        }
    }

