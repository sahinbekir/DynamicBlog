using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class WriterValidator:AbstractValidator<Writer>
	{
		public WriterValidator()
		{
			RuleFor(x => x.WriterName).NotEmpty().WithMessage("Ad soyad boş olmaz.");
			RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Ad soyad 50+ olmaz.");
			RuleFor(x => x.WriterName).MinimumLength(5).WithMessage("Ad soyad 5- olmaz.");
		}
	}
}
