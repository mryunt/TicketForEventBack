using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.DAL.Dtos.Event;

namespace TicketForEvent.Business.Validation.Event
{
    public class EventUpdateValidator : AbstractValidator<UpdateEventDto>
    {
        public EventUpdateValidator()
        {
            RuleFor(p => p.EventTypeId).NotEmpty().WithMessage("Etkinlik Türü ID' si boş bırakılamaz!");
            RuleFor(p => p.SalonId).NotEmpty().WithMessage("Salon ID' si boş bırakılamaz!");
            RuleFor(p => p.StartDate).NotEmpty().WithMessage("Başlangıç Tarihi Boş Bırakılamaz!");
            RuleFor(p => p.EndDate).NotEmpty().WithMessage("Bitiş tarihi boş bırakılamaz!");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Etkinlik ismi boş bırakılamaz!");
            RuleFor(p => p.Explanation).NotEmpty().WithMessage("Açıklama Alanı boş bırakılamaz!");
            RuleFor(p => p.Image).NotEmpty().WithMessage("Resim Alanı Boş bırakılamaz!");
        }
    }
}
