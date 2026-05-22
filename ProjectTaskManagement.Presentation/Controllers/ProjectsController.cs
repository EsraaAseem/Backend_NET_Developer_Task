using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectTaskManagement.Application.Features.Projects.Commands.CreateProject;
using ProjectTaskManagement.Application.Features.Projects.Commands.DeleteProject;
using ProjectTaskManagement.Application.Features.Projects.Commands.UpdateProject;
using ProjectTaskManagement.Application.Features.Projects.Queries.GetAllProjects;
using ProjectTaskManagement.Application.Features.Projects.Queries.GetProjectById;

namespace ProjectTaskManagement.Presentation.Controllers
{
    [Authorize]
    public class ProjectsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(
            CreateProjectRequestDto dto)
        {
            var result = await Mediator.Send(
                new CreateProjectCommand(dto));

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(
                new GetAllProjectsQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(
                new GetProjectByIdQuery(id));

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            UpdateProjectRequestDto dto)
        {
            var result = await Mediator.Send(
                new UpdateProjectCommand(dto));

            return StatusCode((int)result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(
                new DeleteProjectCommand(id));

            return Ok(result);
        }
    }
}
