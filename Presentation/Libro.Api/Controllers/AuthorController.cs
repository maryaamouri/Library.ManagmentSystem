using Libro.Application.Authors;

using Microsoft.AspNetCore.Mvc;

namespace Libro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
     
        public AuthorController(IAuthorService bookService)
        {
            _authorService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<AuthorDto>>> Get()
        {
           return Ok(await _authorService.GetListAsync());
        }

 
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> Get(Guid id)
        {
            return Ok(await _authorService.GetByIdAsync(id)); 
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Post( [FromBody] AuthorRequest request)
        {
            var responce = await _authorService.CreateAsync(request);
            return Ok(responce);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorDto>> Put(Guid id, [FromBody] AuthorRequest request)
        {
            var responce = await _authorService.UpdateAsync(id, request);
            return Ok(responce);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _authorService.DeleteAsync(id);
            return Ok();
        }
    }
}
