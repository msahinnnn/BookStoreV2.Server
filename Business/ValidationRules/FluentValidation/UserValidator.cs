using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.ViewModels.UserVM;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<CreateUserVM>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("First name cannot be empty!");
            RuleFor(u => u.FirstName).MinimumLength(2).WithMessage("First name must be at least 2 characters!"); 

            RuleFor(u => u.LastName).NotEmpty().WithMessage("Last name cannot be empty!"); 
            RuleFor(u => u.LastName).MinimumLength(2).WithMessage("Last name must be at least 2 characters!"); 

            RuleFor(u => u.Email).NotEmpty().WithMessage("Email cannot be empty!"); 
            RuleFor(u => u.Email).EmailAddress().WithMessage("Email must be mail address type!");

            RuleFor(u => u.Password).NotEmpty().WithMessage("Password cannot be empty!");
            RuleFor(u => u.LastName).MinimumLength(8).WithMessage("Last name must be at least 8 characters!");

        }
    }
}
