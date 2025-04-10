using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Commands.CommentCommands;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.CommentHandlers
{
    public class CreateCommentCommandHandler:IRequestHandler<CreateCommentCommand>
    {
        private readonly ICommentService _commentService;

        public CreateCommentCommandHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task Handle(CreateCommentCommand request,CancellationToken cancellationToken)
        {
            await _commentService.AddAsync(new EntityLayer.Entities.Comment
            {
                TaskItemId = request.TaskItemId,
                UserId = request.UserId,
                Content = request.Content,
                CreatedDate = request.CreatedDate
            });
        }
}
}
