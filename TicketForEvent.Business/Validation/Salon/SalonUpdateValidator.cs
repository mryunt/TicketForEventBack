using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.DAL.Dtos.Salon;

namespace TicketForEvent.Business.Validation.Salon
{
    public class SalonUpdateValidator : AbstractValidator<UpdateSalonDto>
    {
        public SalonUpdateValidator()
        {
            RuleFor(p => p.OpenAddressId).NotEmpty().WithMessage("Salon ID' si boş bırakılamaz!");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Salon ismi alanı boş bırakılamaz!");
        }
    }
}
