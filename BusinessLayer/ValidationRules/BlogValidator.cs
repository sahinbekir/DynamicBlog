using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class BlogValidator:AbstractValidator<Blog>
	{
		public BlogValidator()
		{
			RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Başlığı Olmalı...");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog İçeriği Olmalı...");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog Resmi Olmalı...");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Blog Başlığı max 150 karakter Olmalı...");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Blog Başlığı min 5 karakter Olmalı...");

        }
    }
}
