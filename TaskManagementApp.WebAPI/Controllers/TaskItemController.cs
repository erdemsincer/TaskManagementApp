using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TaskManagementApp.BusinessLayer.Features.Mediator.Commands.TaskItemCommands;

using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.TaskltemQueries;
using TaskManagementApp.WebAPI.Hubs;

namespace TaskManagementApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHubContext<NotificationHub> _hubContext;

        public TaskItemController(IMediator mediator, IHubContext<NotificationHub> hubContext)
        {
            _mediator = mediator;
            _hubContext = hubContext;
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

            // 🔔 SignalR bildirimi
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", $"📌 Yeni görev oluşturuldu: {command.Title}");

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

        [HttpGet("GetByProject/{projectId}")]
        public async Task<IActionResult> GetTasksByProject(int projectId)
        {
            var result = await _mediator.Send(new GetTasksByProjectIdQuery(projectId));
            return Ok(result);
        }

        [HttpGet("GetByUser/{userId}")]
        public async Task<IActionResult> GetTasksByUser(int userId)
        {
            var result = await _mediator.Send(new GetTasksByUserIdQuery(userId));
            return Ok(result);
        }

        [HttpGet("GetByStatus/{status}")]
        public async Task<IActionResult> GetTasksByStatus(string status)
        {
            var result = await _mediator.Send(new GetTasksByStatusQuery(status));
            return Ok(result);
        }

        [HttpGet("GetOverdue")]
        public async Task<IActionResult> GetOverdueTasks()
        {
            var result = await _mediator.Send(new GetOverdueTasksQuery());
            return Ok(result);
        }
        [HttpPut("UpdateStatus")]
        public async Task<IActionResult> UpdateTaskStatus(UpdateTaskItemStatusCommand command)
        {
            await _mediator.Send(command);
            return Ok("Görev durumu güncellendi.");
        }
    }
}
