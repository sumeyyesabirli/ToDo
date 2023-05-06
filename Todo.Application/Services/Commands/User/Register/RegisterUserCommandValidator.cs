using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Services.Commands.User.Register
{
    public class RegisterUserCommandValidator:AbstractValidator<Todo.Core.Entities.User>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(i => i.Email).NotEmpty().EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("{PropertyName} validasyona uygun değil");

            RuleFor(i => i.Password).NotNull().MinimumLength(6).WithMessage("{PropertyName} en az {MinLengt} olmalıdır ");
        }
    }
}
