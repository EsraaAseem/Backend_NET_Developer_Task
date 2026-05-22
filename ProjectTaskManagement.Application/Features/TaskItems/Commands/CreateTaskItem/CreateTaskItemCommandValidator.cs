
using FluentValidation;

namespace ProjectTaskManagement.Application.Features.TaskItems.Commands.CreateTaskItem
{
    public class CreateTaskItemCommandValidator
        : AbstractValidator<CreateTaskItemCommand>
    {
        public CreateTaskItemCommandValidator()
        {
            RuleFor(x => x.Model.Title)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Model.Description)
                .MaximumLength(500);

            RuleFor(x => x.Model.ProjectId)
                .NotEmpty();
            RuleFor(x => x.Model.Priority)
               .LessThan(100);
        }
    }
}
