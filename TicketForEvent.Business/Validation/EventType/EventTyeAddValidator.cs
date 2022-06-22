using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.DAL.Dtos.EventType;

namespace TicketForEvent.Business.Validation.EventType
{
    public class EventTyeAddValidator : AbstractValidator<AddEventTypeDto>
    {
        public EventTyeAddValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Etklinlik Adı Alanı Boş Bırakılamaz!");
        }
    }
}
