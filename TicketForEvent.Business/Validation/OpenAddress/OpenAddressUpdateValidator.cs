using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.DAL.Dtos.OpenAddress;

namespace TicketForEvent.Business.Validation.OpenAddress
{
    public class OpenAddressUpdateValidator : AbstractValidator<UpdateOpenAddressDto>
    {
        public OpenAddressUpdateValidator()
        {
            RuleFor(p => p.CountryId).NotEmpty().WithMessage("Ülke ID' si boş bırakılamaz!");
            RuleFor(p => p.CityId).NotEmpty().WithMessage("Şehir ID' si boş bırakılamaz!");
            RuleFor(p => p.TownshipId).NotEmpty().WithMessage("İlçe ID' si boş bırakılamaz!");
            RuleFor(p => p.NeighborhoodId).NotEmpty().WithMessage("Mahalle ID' si boş bırakılamaz!");
            RuleFor(p => p.StreetId).NotEmpty().WithMessage("Sokak ID' si boş bırakılamaz!");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Açık Adres Alanı Boş Bırakılamaz!");
        }
    }
}
