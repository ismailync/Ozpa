using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.ContactName).NotEmpty().WithMessage("Bu Alan Zorunludur");
            RuleFor(x => x.ContactEMail).NotEmpty().WithMessage("Bu Alan Zorunludur");
            RuleFor(x => x.ContactMessage).NotEmpty().WithMessage("Bu Alan Zorunludur");
            RuleFor(x => x.ContactSubject).NotEmpty().WithMessage("Bu Alan Zorunludur");
        }
    }
}
