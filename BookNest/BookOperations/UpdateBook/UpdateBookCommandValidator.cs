﻿using FluentValidation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookNest.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.BookId).GreaterThan(0);
            RuleFor(x=>x.Model.GenreId).GreaterThan(0);
            RuleFor(x=>x.Model.Title).MinimumLength(5);
            RuleFor(x => x.Model.PageCount).GreaterThan(0);
            RuleFor(x=>x.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}
