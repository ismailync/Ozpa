using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BannerValidator : AbstractValidator<Banner>
    {
        public BannerValidator()
        {
            RuleFor(x => x.BannerImage).NotEmpty().WithMessage("Resmi boş bırakma!!");
            RuleFor(x => x.CategoryId).NotNull().WithMessage("Kategoriyi boş bırakma!!");  
        }
    }
}
