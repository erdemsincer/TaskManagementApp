using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.CommentQueries;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.CommentResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery,GetCommentByIdQueryResult>
    {
        private readonly ICommentService _commentService;

        public GetCommentByIdQueryHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<GetCommentByIdQueryResult> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _commentService.GetByIdAsync(request.Id);
            return new GetCommentByIdQueryResult
            {
                Id = values.Id,
                Content = values.Content,
                CreatedDate = values.CreatedDate,
                TaskItemId = values.TaskItemId,
                UserId = values.UserId
            };
        }
    }
}
