using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using QuadrasNatal.Application.Models;

namespace QuadrasNatal.Application.Validators
{
    public class InsertUserValidator : AbstractValidator<CreateUserInputModel>
    {
        public InsertUserValidator()
        {

            RuleFor(u => u.Email)
                .EmailAddress()
                    .WithMessage("email invalido");

            RuleFor(u => u.BirthDate)
                .Must(d => d < DateTime.Now.AddYears(-18))
                    .WithMessage("Deve ser maior de idade.");
        }
           
    }
}