using Libro.Application.Transations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransationController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransationController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<TransactionDto>>> Get()
        {
            return Ok(await _transactionService.GetListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDto>> Get(Guid id)
        {
            return Ok(await _transactionService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<TransactionDto>> Post([FromBody] TransactionRequest request)
        {
            var responce = await _transactionService.CreateAsync(request);
            return Ok(responce);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TransactionDto>> Put(Guid id, [FromBody] TransactionRequest request)
        {
            var responce = await _transactionService.UpdateAsync(id, request);
            return Ok(responce);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _transactionService.DeleteAsync(id);
            return Ok();
        }
    }
}
