
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectTaskManagement.Application.Features.TaskItems.Commands.CreateTaskItem;
using ProjectTaskManagement.Application.Features.TaskItems.Commands.DeleteTaskItem;
using ProjectTaskManagement.Application.Features.TaskItems.Commands.UpdateTaskStatus;
using ProjectTaskManagement.Application.Features.TaskItems.Queries.GetTasksByProject;

namespace ProjectTaskManagement.Presentation.Controllers
{
    [Authorize]
    public class TaskItemsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(
            CreateTaskItemRequestDto dto)
        {
            var result = await Mediator.Send(
                new CreateTaskItemCommand(dto));

            return Ok(result);
        }

        [HttpPut("status")]
        public async Task<IActionResult> UpdateStatus(
            UpdateTaskStatusRequestDto dto)
        {
            var result = await Mediator.Send(
                new UpdateTaskStatusCommand(dto));

            return Ok(result);
        }

        [HttpGet("project/{projectId}")]
        public async Task<IActionResult> GetByProject(
            int projectId)
        {
            var result = await Mediator.Send(
                new GetTasksByProjectQuery(projectId));

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(
                new DeleteTaskItemCommand(id));

            return Ok(result);
        }
    }
}
