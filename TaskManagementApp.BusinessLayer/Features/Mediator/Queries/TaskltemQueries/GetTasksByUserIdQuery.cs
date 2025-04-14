using MediatR;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.TaskItemResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Queries.TaskltemQueries
{
    public class GetTasksByUserIdQuery : IRequest<List<UserTaskResult>>
    {
        public int UserId { get; set; }

        public GetTasksByUserIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
