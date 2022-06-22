using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.DAL.Dtos.Neighborhood;

namespace TicketForEvent.Business.Validation.Neighborhood
{
    public class NeighborhoodUpdateValidator : AbstractValidator<UpdateNeighborhoodDto>
    {
        public NeighborhoodUpdateValidator()
        {
            RuleFor(p => p.TownshipId).NotEmpty().WithMessage("İlçe ID' si alanı boş bırakılamaz!");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Mahalle ismi alanı boş bırakılamaz!");
        }
    }
}
