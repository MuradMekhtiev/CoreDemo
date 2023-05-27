using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator: AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Please fill out this field.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Please fill out this field.");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Maximum length for category name is 50 characters.");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Minimum length for category name is 2 characters.");
        }
    }
}
