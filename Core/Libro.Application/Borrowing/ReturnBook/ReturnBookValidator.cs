using FluentValidation;

namespace Libro.Application.Borrowing.ReturnBook
{
    public class ReturnBookValidator : AbstractValidator<ReturnBookCommand>
    {
        public ReturnBookValidator()
        {

            RuleFor(rbc => rbc.TranactionId)
                    .NotEmpty().WithMessage("Transaction Is Required.");

            RuleFor(rbc => rbc.BookId)
                    .NotEmpty().WithMessage("Book Is Required.");

        }
    }
}
