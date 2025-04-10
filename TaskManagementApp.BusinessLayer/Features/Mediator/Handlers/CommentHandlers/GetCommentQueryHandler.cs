using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.CommentQueries;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.CommentResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, List<GetCommentQueryResult>
    {
        private readonly ICommentService _commentService;

        public GetCommentQueryHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<List<GetCommentQueryResult>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentService.GetAllAsync();
            var commentResults = comments.Select(c => new GetCommentQueryResult
            {
                Id = c.Id,
                TaskItemId = c.TaskItemId,
                UserId = c.UserId,
                Content = c.Content,
                CreatedDate = c.CreatedDate
            }).ToList();

            return commentResults;
        }
    }
}
