using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.DAL.Dtos.Country;

namespace TicketForEvent.Business.Validation.Country
{
    public class CountryUpdateValidator : AbstractValidator<UpdateCountryDto>
    {
        public CountryUpdateValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Ülke İsmi Alanı Boş Bırakılamaz!");
        }
    }
}
