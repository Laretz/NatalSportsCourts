using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using QuadrasNatal.Application.Commands.InsertBooking;

namespace QuadrasNatal.Application.Validators
{
    public class InsertBookingValidator : AbstractValidator<InsertBookingCommand>
    {
        public InsertBookingValidator()
        {
            RuleFor(b => b.Sport)
                .NotEmpty()
                    .WithMessage("Precisa adcionar um esporte")
                .MaximumLength(50);
                   
        }
    }
}