using MediatR;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Commands.CommentCommands
{
    public class RemoveCommentCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveCommentCommand(int ıd)
        {
            Id = ıd;
        }
    }
   
}
