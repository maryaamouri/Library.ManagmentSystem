using Libro.Application.Borrowing.CancleReservation;
using Libro.Application.Borrowing.ConfirmReceipt;
using Libro.Application.Borrowing.Reservation;
using Libro.Application.Borrowing.ReturnBook;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Libro.Api.Borrowing
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
        [Authorize]
        public async Task<IActionResult> ReserveBook(ReserveBookCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("cancel")]
        [Authorize]
        public async Task<IActionResult> CancelReservation(CancleResarvationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("confirm")]
        [Authorize]
        public async Task<IActionResult> ConfirmReceipt(ConfirmReciptCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("return")]
        [Authorize]
        public async Task<IActionResult> ReturnBook(ReturnBookCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
