
using FluentValidation;

namespace ProjectTaskManagement.Application.Features.Projects.Commands.CreateProject
{
    internal class CreateProjectCommandValidator
         : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(x => x.Model.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Model.Description)
                .MaximumLength(500);
        }
    }
}
