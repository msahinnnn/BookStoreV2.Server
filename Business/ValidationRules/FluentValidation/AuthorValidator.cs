using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.ViewModels.Author;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AuthorValidator : AbstractValidator<CreateAuthorVM>
    {
        public AuthorValidator()
        {
            RuleFor(u => u.AuthorName).NotEmpty().WithMessage("Author name cannot be empty!");
            RuleFor(u => u.AuthorName).MinimumLength(4).WithMessage("Author name must be at least 2 characters!");

        }
    }
}
