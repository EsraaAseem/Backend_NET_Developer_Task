using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ProjectTaskManagement.Application.Features.Projects.Commands.DeleteProject
{
    internal class DeleteProjectCommandValidator
        : AbstractValidator<DeleteProjectCommand>
    {
        public DeleteProjectCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
