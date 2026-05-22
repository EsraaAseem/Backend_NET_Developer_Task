
using FluentValidation;

namespace ProjectTaskManagement.Application.Features.TaskItems.Queries.GetTasksByProject
{
    public class GetTasksByProjectQueryValidator
           : AbstractValidator<GetTasksByProjectQuery>
    {
        public GetTasksByProjectQueryValidator()
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty();
        }
    }
}
