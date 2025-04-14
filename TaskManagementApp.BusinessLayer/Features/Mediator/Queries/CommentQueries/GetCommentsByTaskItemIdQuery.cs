using MediatR;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.CommentResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentsByTaskItemIdQuery : IRequest<List<GetCommentsByTaskItemIdResult>>
    {
        public int TaskItemId { get; set; }

        public GetCommentsByTaskItemIdQuery(int taskItemId)
        {
            TaskItemId = taskItemId;
        }
    }
}
