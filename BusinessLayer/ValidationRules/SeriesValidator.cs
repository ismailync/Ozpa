using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SeriesValidator : AbstractValidator<Series>
    {
        public SeriesValidator()
        {
            RuleFor(x => x.SeriesImage).NotEmpty().WithMessage("Resmi boş bırakma!!");       
            RuleFor(x => x.SeriesName).NotEmpty().WithMessage("Adı boş bırakma!!");
            RuleFor(x => x.CategoryId.ToString()).NotEmpty().WithMessage("Kategoriyi boş bırakma");       
        }
    }
}
