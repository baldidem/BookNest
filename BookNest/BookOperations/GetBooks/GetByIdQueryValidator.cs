using FluentValidation;

namespace BookNest.BookOperations.GetBooks
{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator()
        { 
            RuleFor(x=>x.BookId).GreaterThan(0);
        }
    }
}
