
using FluentValidation;

namespace ProjectTaskManagement.Application.Features.Authentication.Login
{
    internal class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Model.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Model.Password)
                .NotEmpty()
                .MinimumLength(6);
        }
    }
}
