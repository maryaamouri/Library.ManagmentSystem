using Libro.Application.Borrowing.CancleReservation;
using Libro.Application.Borrowing.ConfirmReceipt;
using Libro.Application.Borrowing.Reservation;
using Libro.Application.Borrowing.ReturnBook;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Libro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BorrowingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("reserve")]
        [Authorize(Roles = "Patron")]
        public async Task<IActionResult> ReserveBook(ReserveBookCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error.Code);

        }

        [HttpPost("cancel")]
        [Authorize(Roles = "Patron")]
        public async Task<IActionResult> CancelReservation(CancleResarvationCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error.Code);
        }

        [HttpPost("confirm")]
        [Authorize(Roles = "Librarian")]
        public async Task<IActionResult> ConfirmReceipt(ConfirmReciptCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error.Code);
        }

        [HttpPost("return")]
        [Authorize(Roles = "Librarian")]
        public async Task<IActionResult> ReturnBook(ReturnBookCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error.Code);
        }
    }
}
