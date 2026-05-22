
using FluentValidation;

namespace ProjectTaskManagement.Application.Features.Projects.Commands.UpdateProject
{
    internal class UpdateProjectCommandValidator
        : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(x => x.Model.Id)
                .NotEmpty();

            RuleFor(x => x.Model.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Model.Description)
                .MaximumLength(500);
        }
    }
}
