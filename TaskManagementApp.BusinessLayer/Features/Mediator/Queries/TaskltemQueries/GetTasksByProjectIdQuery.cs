using MediatR;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.TaskItemResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Queries.TaskltemQueries
{
    public class GetTasksByProjectIdQuery : IRequest<List<UserTaskResult>>
    {
        public int ProjectId { get; set; }

        public GetTasksByProjectIdQuery(int projectId)
        {
            ProjectId = projectId;
        }
    }
}
