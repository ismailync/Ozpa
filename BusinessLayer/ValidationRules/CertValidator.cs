using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CertValidator : AbstractValidator<Cert>
    {
        public CertValidator()
        {
            RuleFor(x => x.CertImage).NotEmpty().WithMessage("Resmi boş bırakma!!");
            
        }
    }
}
