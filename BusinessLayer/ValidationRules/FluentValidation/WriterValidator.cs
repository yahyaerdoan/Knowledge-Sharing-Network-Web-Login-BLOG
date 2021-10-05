using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı-soyadı boş geçilemez!");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("e-Mail boş geçilemez!");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez!");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar adı-soyadı en az iki karekter olmalıdır!");
            RuleFor(x => x.WriterName).MaximumLength(35).WithMessage("Yazar adı-soyadı en fazla otuz-beş karekter olmalıdır!");

            RuleFor(x => x.WriterPassword).MinimumLength(5).WithMessage("Parolanız en az 5 karakter içermelidir!");
            RuleFor(x => x.WriterPassword).Must(PasswordControl).WithMessage("Oluşturmak İstediğiniz Şifreniz; En Az Bir Rakam, Bir Harf ve 5 Karakterden Oluşmalıdır!");
        }
        private bool PasswordControl(string arg)
        {
            return Regex.IsMatch(arg, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[0-9])[A-Za-z\d]");
        }
    }
}
