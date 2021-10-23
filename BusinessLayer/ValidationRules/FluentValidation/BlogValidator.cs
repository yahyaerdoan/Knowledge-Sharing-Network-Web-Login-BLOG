using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş geçilemez!");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Blog başlığı 150 karekterden fazla olamaz!");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Blog başlığı 5 karekterden az olamaz!");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş geçilemez!");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog görseli boş geçilemez!");
            RuleFor(x => x.BlogThumbnailImage).NotEmpty().WithMessage("Blog küçük görseli boş geçilemez!");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori bilgisi boş geçilemez!");
        }
    }
}
