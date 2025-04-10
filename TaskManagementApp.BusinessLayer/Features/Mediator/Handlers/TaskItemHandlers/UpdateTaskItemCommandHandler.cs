using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Commands.TaskItemCommands;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.TaskItemHandlers
{
    public class UpdateTaskItemCommandHandler:IRequestHandler<UpdateTaskItemCommand>
    {
        private readonly ITaskItemService _taskItemService;

        public UpdateTaskItemCommandHandler(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        public async Task Handle(UpdateTaskItemCommand request,CancellationToken cancellationToken)
        {
            var values = await _taskItemService.GetByIdAsync(request.Id);
            values.Title = request.Title;
            values.Description = request.Description;
            values.Status = request.Status;
            values.Deadline = request.Deadline;
            values.Priority = request.Priority;
            values.ProjectId = request.ProjectId;
            values.AssignedToUserId = request.AssignedToUserId;
            await _taskItemService.UpdateAsync(values);

        }
    }
}
