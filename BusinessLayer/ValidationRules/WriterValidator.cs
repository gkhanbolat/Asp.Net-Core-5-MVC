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
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("İsim Boş olamaz.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail boş olamaz.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş olamaz.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("İsim min 2 harfli olmalıdır.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("İsim max 50 harfli olmalıdır.");
        }
    }
}
