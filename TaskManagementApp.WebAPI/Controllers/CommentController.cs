using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.BusinessLayer.Features.Mediator.Commands.CommentCommands;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.CommentQueries;

namespace TaskManagementApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
       private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
           var values= await _mediator.Send(new GetCommentQuery());
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
            return Ok("Comment başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveComment(int id)
        {
            await _mediator.Send(new RemoveCommentCommand(id));
            return Ok("Comment başarıyla silindi");
        }
    }
}
