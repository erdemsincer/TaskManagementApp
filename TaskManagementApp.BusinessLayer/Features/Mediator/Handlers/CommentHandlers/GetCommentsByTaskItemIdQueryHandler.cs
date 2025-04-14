using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.CommentQueries;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.CommentResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentsByTaskItemIdQueryHandler : IRequestHandler<GetCommentsByTaskItemIdQuery, List<GetCommentsByTaskItemIdResult>>
    {
        private readonly ICommentService _commentService;

        public GetCommentsByTaskItemIdQueryHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<List<GetCommentsByTaskItemIdResult>> Handle(GetCommentsByTaskItemIdQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentService.GetCommentsWithUserByTaskItemIdAsync(request.TaskItemId);

            return comments.Select(c => new GetCommentsByTaskItemIdResult
            {
                Id = c.Id,
                UserId = c.UserId,
                Content = c.Content,
                CreatedDate = c.CreatedDate,
                UserFullName = c.User?.FullName
            }).ToList();
        }
    }
}
