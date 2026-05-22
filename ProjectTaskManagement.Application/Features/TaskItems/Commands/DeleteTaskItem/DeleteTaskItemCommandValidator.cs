
using FluentValidation;

namespace ProjectTaskManagement.Application.Features.TaskItems.Commands.DeleteTaskItem
{
    internal class DeleteTaskItemCommandValidator
       : AbstractValidator<DeleteTaskItemCommand>
    {
        public DeleteTaskItemCommandValidator()
        {
            RuleFor(x => x.TaskId)
                .NotEmpty();
        }
    }
}
