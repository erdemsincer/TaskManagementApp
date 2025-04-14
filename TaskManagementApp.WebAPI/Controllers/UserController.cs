using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.UserQueries;

namespace TaskManagementApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/User
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            if (user == null)
                return NotFound("Kullanıcı bulunamadı.");

            return Ok(user);
        }
        [HttpGet("GetUserWithTasks/{id}")]
        public async Task<IActionResult> GetUserWithTasks(int id)
        {
            var result = await _mediator.Send(new GetUserWithTasksQuery(id));
            if (result == null)
                return NotFound("Kullanıcı bulunamadı");

            return Ok(result);
        }

        // ✅ 2. Kullanıcının görev ve yorum sayısı
        [HttpGet("GetUserActivitySummary/{id}")]
        public async Task<IActionResult> GetUserActivitySummary(int id)
        {
            var result = await _mediator.Send(new GetUserActivitySummaryQuery(id));
            return Ok(result);
        }

    }
}

