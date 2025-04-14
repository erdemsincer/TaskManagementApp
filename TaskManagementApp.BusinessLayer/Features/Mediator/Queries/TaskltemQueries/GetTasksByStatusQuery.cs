using MediatR;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.TaskItemResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Queries.TaskltemQueries
{
    public class GetTasksByStatusQuery : IRequest<List<UserTaskResult>>
    {
        public string Status { get; set; }

        public GetTasksByStatusQuery(string status)
        {
            Status = status;
        }
    }
}
