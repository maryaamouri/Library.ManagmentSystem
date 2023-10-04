using Libro.Application.Books;
using Microsoft.AspNetCore.Mvc;

namespace Libro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
       
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<BookDto>>> Get()
        {
           return Ok(await _bookService.GetListAsync());
        }

 
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> Get(Guid id)
        {
            return Ok(await _bookService.GetByIdAsync(id)); 
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> Post( [FromBody] BookRequest book)
        {
            var responce = await _bookService.CreateAsync(book);
            return Ok(responce);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookDto>> Put(Guid id, [FromBody] BookRequest book)
        {
            var responce = await _bookService.UpdateAsync(id, book);
            return Ok(responce);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _bookService.DeleteAsync(id);
            return Ok();
        }
    

    }
}
