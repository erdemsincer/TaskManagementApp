using MediatR;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.TaskItemResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Queries.TaskltemQueries
{
    public class GetOverdueTasksQuery : IRequest<List<UserTaskResult>>
    {
    }
}
