using FluentValidation;
using TemplateDDD.Domain.Commands.Sample;
using TemplateDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateDDD.Service.Validators
{
    class LoginAccountValidator : AbstractValidator<LoginAccountCommand>
    {
        public LoginAccountValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(c => c.User)
                .NotEmpty().WithMessage("User Not Set");
            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Password Not Set");
        }
    }
}
