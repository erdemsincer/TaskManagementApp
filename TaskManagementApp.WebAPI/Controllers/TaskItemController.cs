using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.BusinessLayer.Features.Mediator.Commands.TaskItemCommands;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.TaskltemQueries;

namespace TaskManagementApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TaskItemList()
        {
            var values = await _mediator.Send(new GetTaskItemQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskItem(int id)
        {
            var value = await _mediator.Send(new GetTaskItemByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskItem(CreateTaskItemCommand command)
        {
            await _mediator.Send(command);
            return Ok("Task Item başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTaskItem(int id)
        {
            await _mediator.Send(new RemoveTaskItemCommand(id));
            return Ok("Task Item başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTaskItem(UpdateTaskItemCommand command)
        {
            await _mediator.Send(command);
            return Ok("Task Item başarıyla güncellendi");
        }
    }
}
