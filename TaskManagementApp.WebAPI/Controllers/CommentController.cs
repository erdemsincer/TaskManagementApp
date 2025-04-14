using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TaskManagementApp.BusinessLayer.Features.Mediator.Commands.CommentCommands;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.CommentQueries;
using TaskManagementApp.WebAPI.Hubs;

namespace TaskManagementApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHubContext<NotificationHub> _hubContext;

        public CommentController(IMediator mediator, IHubContext<NotificationHub> hubContext)
        {
            _mediator = mediator;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            var values = await _mediator.Send(new GetCommentQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var value = await _mediator.Send(new GetCommentByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommand command)
        {
            await _mediator.Send(command);

            // 🟢 SignalR ile yorum bildirimi
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", $"💬 Yeni yorum: {command.Content}");

            return Ok("Comment başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveComment(int id)
        {
            await _mediator.Send(new RemoveCommentCommand(id));
            return Ok("Comment başarıyla silindi");
        }

        [HttpGet("GetByTaskItem/{taskItemId}")]
        public async Task<IActionResult> GetCommentsByTaskItemId(int taskItemId)
        {
            var result = await _mediator.Send(new GetCommentsByTaskItemIdQuery(taskItemId));
            return Ok(result);
        }
    }
}
