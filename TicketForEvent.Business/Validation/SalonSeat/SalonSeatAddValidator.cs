using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketForEvent.DAL.Dtos.SalonSeat;

namespace TicketForEvent.Business.Validation.SalonSeat
{
    public class SalonSeatAddValidator : AbstractValidator<AddSalonSeatDto>
    {
        public SalonSeatAddValidator()
        {
            RuleFor(p => p.SalonId).NotEmpty().WithMessage("Salon ID' si boş bırakılamaz!");
            RuleFor(p => p.SeatId).NotEmpty().WithMessage("Koltuk ID' si boş bırakılamaz!");
        }
    }
}
