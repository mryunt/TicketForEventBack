using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.DAL.Dtos.City;

namespace TicketForEvent.Business.Validation.City
{
    public class CityAddValidator : AbstractValidator<AddCityDto>
    {
        public CityAddValidator()
        {
            RuleFor(p => p.CountryId).NotEmpty().WithMessage("Ülke ID' si Boş Bırakılamaz!");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Şehir İsmi Boş Bırakılamaz!");
        }
    }
}
