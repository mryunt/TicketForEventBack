using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.DAL.Dtos.Street;

namespace TicketForEvent.Business.Validation.Street
{
    public class StreetUpdateValidator : AbstractValidator<UpdateStreetDto>
    {
        public StreetUpdateValidator()
        {
            RuleFor(p => p.NeighborhoodId).NotEmpty().WithMessage("Mahalle ID' si boş bırakılamaz!");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Sokak İsmi boş bırakılamaz!");
        }
    }
}
