using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class WriterValidator: AbstractValidator<Writer>
	{
		public WriterValidator()
		{
			RuleFor(x => x.WriterName).NotEmpty().WithMessage("Please fill out Username section.");
			RuleFor(x => x.WriterEmail).NotEmpty().WithMessage("Please fill out Email section.");
			RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Please fill out Password section.");
			RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Please fill out Image section.");
			RuleFor(x => x.WriterPassword).MinimumLength(8).WithMessage("The password should be at least 8 characters long.");
			RuleFor(p => p.WriterPassword).Matches(@"[A-Z]+").WithMessage("Password should contain at least one upper case letter.");
			RuleFor(p => p.WriterPassword).Matches(@"[a-z]+").WithMessage("Password should contain at least one lower case letter.");
			RuleFor(p => p.WriterPassword).Matches(@"[0-9]+").WithMessage("Password should contain at least one number.");
		}
	}
}
