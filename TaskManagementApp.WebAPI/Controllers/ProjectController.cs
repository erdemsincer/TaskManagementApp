using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.BusinessLayer.Features.Mediator.Commands.ProjectCommand;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.ProjectQueries;

namespace TaskManagementApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ProjectList()
        {
            var values = await _mediator.Send(new GetProjectQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            var value = await _mediator.Send(new GetProjctByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectCommand command)
        {
            await _mediator.Send(command);
            return Ok("Proje başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveProject(int id)
        {
            await _mediator.Send(new RemoveProjectCommand(id));
            return Ok("Proje başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProject(UpdateProjectCommand command)
        {
            await _mediator.Send(command);
            return Ok("Proje başarıyla güncellendi");
        }
    }
}
