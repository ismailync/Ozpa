using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminLoginValidator : AbstractValidator<AdminLogin>
    {
        public AdminLoginValidator()
        {
            RuleFor(x => x.LoginName).NotEmpty().WithMessage("Adı boş geçme!!");
            RuleFor(x => x.LoginName).MinimumLength(4).WithMessage("Ad en az 4 karakter olmalı!!");
            RuleFor(x => x.LoginPassword).NotNull().WithMessage("Şifreyi boş geçme!!");
            RuleFor(x => x.LoginPassword.ToString()).MinimumLength(6).WithMessage("En az 6 karakterli olmalı!!");
        }
    }
}
