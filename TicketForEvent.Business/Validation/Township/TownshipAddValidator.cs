using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.DAL.Dtos.Township;

namespace TicketForEvent.Business.Validation.Township
{
    public class TownshipAddValidator : AbstractValidator<AddTownshipDto>
    {
        public TownshipAddValidator()
        {
            RuleFor(p => p.CityId).NotEmpty().WithMessage("Şehir ID' si Alanı Boş Bırakılaaz!");
            RuleFor(p => p.Name).NotEmpty().WithMessage("İlçe İsmi Boş Bırakılamaz!");
        }
    }
}
