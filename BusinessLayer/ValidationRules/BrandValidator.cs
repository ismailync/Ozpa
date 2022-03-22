using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(x => x.BrandImage).NotEmpty().WithMessage("Resmi boş bırakma!!");
            RuleFor(x => x.BrandName).NotEmpty().WithMessage("Adı boş bırakma!!");
        }
    }
}
