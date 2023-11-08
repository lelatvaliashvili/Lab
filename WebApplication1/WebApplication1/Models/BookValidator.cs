using FluentValidation;
using Microsoft.EntityFrameworkCore;
using LibraryBookService.Data;

namespace LibraryBookService.Models
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Name of the book should be provided"); ;

            RuleFor(x => x.Author)
               .NotNull()
               .NotEmpty()
               .WithMessage("At least the name should be provided"); ;

            RuleFor(x => x.PublishDate).NotNull().NotEmpty()
                 .LessThan(DateTime.Now)
                            .WithMessage("Publish date must be in the past");
        }
    }
}
