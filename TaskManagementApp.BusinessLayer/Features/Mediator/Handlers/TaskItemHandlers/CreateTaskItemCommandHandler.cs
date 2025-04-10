using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Commands.TaskItemCommands;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.TaskItemHandlers
{
    public class CreateTaskItemCommandHandler:IRequestHandler<CreateTaskItemCommand>
    {
        private readonly ITaskItemService _taskItemService;

        public CreateTaskItemCommandHandler(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        public async Task Handle(CreateTaskItemCommand request,CancellationToken cancellationToken)
        {
            await _taskItemService.AddAsync(new EntityLayer.Entities.TaskItem
            {
                Title = request.Title,
                Description = request.Description,
                ProjectId = request.ProjectId,
                AssignedToUserId = request.AssignedToUserId,
                Status = request.Status,
                Priority = request.Priority,
                Deadline = request.Deadline,
                CreatedDate = request.CreatedDate
            });
        }
    }
    
}
