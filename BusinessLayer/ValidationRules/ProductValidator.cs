using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Adı boş bırakma!!");
            RuleFor(x => x.ProductImage).NotEmpty().WithMessage("Resmi boş bırakma!!");
            RuleFor(x => x.ProductTrend).NotEmpty().WithMessage("Trendi True ya da False yaz!!");
            RuleFor(x => x.BrandId).NotEmpty().WithMessage("Markayı boş bırakma!!");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategoriyi boş bırakma!!");
        }
    }
}
