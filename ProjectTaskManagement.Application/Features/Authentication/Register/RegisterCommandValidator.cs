
using FluentValidation;

namespace ProjectTaskManagement.Application.Features.Authentication.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Model.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Model.UserName)
                .NotEmpty();

            RuleFor(x => x.Model.Password)
                .NotEmpty()
                .MinimumLength(6);
        }
    }
}
