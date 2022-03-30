using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategoriyi boş bırakma!!");
            //RuleFor(x => x.CategoryParentId.ToString()).NotEmpty().WithMessage("Kategori 2 yi boş bırakma!!");
            RuleFor(p => p.CategoryParentId).NotNull().WithMessage("Kategoriyi boş bırakma!!");
        }
    }
}
