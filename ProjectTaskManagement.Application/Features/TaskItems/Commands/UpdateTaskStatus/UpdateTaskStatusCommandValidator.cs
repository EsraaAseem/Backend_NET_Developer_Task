
using FluentValidation;

namespace ProjectTaskManagement.Application.Features.TaskItems.Commands.UpdateTaskStatus
{
    internal class UpdateTaskStatusCommandValidator
         : AbstractValidator<UpdateTaskStatusCommand>
    {
        public UpdateTaskStatusCommandValidator()
        {
            RuleFor(x => x.Model.TaskId)
                .NotEmpty();

            RuleFor(x => x.Model.Status)
                .IsInEnum();
        }
    }
}
