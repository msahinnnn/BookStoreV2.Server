using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.ViewModels.Book;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BookValidator : AbstractValidator<CreateBookVM>
    {
        public BookValidator()
        {
            RuleFor(u => u.BookName).NotEmpty().WithMessage("Book ISBN cannot be empty!");
            RuleFor(u => u.BookName).MinimumLength(2).WithMessage("Book ISBN must be at least 2 characters!");

            RuleFor(u => u.BookISBN).NotEmpty().WithMessage("Book ISBN  cannot be empty!");
            RuleFor(u => u.BookISBN).MinimumLength(6).WithMessage("Book ISBN  must be at least 2 characters!");

        }
    }
}
