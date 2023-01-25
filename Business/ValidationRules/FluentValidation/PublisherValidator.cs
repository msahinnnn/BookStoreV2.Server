using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.ViewModels.Publisher;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PublisherValidator : AbstractValidator<CreatePublisherVM>
    {
        public PublisherValidator()
        {
            RuleFor(u => u.PublisherName).NotEmpty().WithMessage("Publisher name cannot be empty!");
            RuleFor(u => u.PublisherName).MinimumLength(2).WithMessage("Publisher name must be at least 2 characters!");

        }
    }
}
