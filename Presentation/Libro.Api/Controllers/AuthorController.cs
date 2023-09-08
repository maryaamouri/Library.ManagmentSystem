
using Libro.Application.Authors;
using Microsoft.AspNetCore.Mvc;

namespace Libro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _bookService;

        public AuthorController(IAuthorService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<AuthorDto>>> Get()
        {
           return Ok(await _bookService.GetListAsync());
        }

 
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> Get(Guid id)
        {
            return Ok(await _bookService.GetByIdAsync(id)); 
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Post( [FromBody] AuthorRequest book)
        {
            var responce = await _bookService.CreateAsync(book);
            return Ok(responce);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorDto>> Put(Guid id, [FromBody] AuthorRequest book)
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
