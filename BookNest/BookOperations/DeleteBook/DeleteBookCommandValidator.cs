using FluentValidation;
using static BookNest.BookOperations.DeleteBook.DeleteBookCommand;

namespace BookNest.BookOperations.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(x => x.BookId).GreaterThan(0);
        }
    }
}
