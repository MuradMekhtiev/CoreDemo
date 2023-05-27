using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator: AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Please fill out this field.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Please fill out this field.");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Please fill out this field.");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Blog title length can not be more than 150 characters.");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Blog title length can not be less than 5 characters.");
            RuleFor(x => x.BlogContent).MinimumLength(150).WithMessage("Blog content length can not be less than 150 characters.");
        }
    }
}
