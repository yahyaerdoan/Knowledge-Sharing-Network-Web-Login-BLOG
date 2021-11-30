using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori ismi boş geçilemez!");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Kategori ismi min iki karakter olmalıdır!");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Kategori ismi max elli karakter olmalıdır!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklaması boş geçilemez!");
            RuleFor(x => x.CategoryDescription).MinimumLength(5).WithMessage("Kategori açıklaması min beş karakter olmalıdır!");
            RuleFor(x => x.CategoryDescription).MaximumLength(50).WithMessage("Kategori açıklaması max elli karakter olmalıdır!");
        }
    }
}
