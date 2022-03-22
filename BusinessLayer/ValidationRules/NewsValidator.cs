using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class NewsValidator : AbstractValidator<News>
    {
        public NewsValidator()
        {
            RuleFor(x => x.NewsImage).NotEmpty().WithMessage("Resmi boş bırakma!!");
            RuleFor(x => x.NewsTitle).NotEmpty().WithMessage("Başlığı boş bırakma!!");
            RuleFor(x => x.NewsComment).NotEmpty().WithMessage("Açıklamayı boş bırakma!!");
            RuleFor(x => x.NewsTitle).MinimumLength(6).WithMessage("Başlığı 6 karakter olamlı!!");
            RuleFor(x => x.NewsComment).MinimumLength(6).WithMessage("Açıklama 6 karakter olamlı!!");
        }
    }
}
