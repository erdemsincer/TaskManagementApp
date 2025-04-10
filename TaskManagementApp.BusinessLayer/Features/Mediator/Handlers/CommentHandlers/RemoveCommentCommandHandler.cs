using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Commands.CommentCommands;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.CommentHandlers
{
    public class RemoveCommentCommandHandler : IRequestHandler<RemoveCommentCommand>
    {
        private readonly ICommentService _commentService;

        public RemoveCommentCommandHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentService.GetByIdAsync(request.Id);
            if (comment != null)
            {
                await _commentService.DeleteAsync(comment);
            }
        }
    }
}
    