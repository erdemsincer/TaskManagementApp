using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Commands.TaskItemCommands;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.TaskItemHandlers
{
    public class UpdateTaskItemStatusCommandHandler : IRequestHandler<UpdateTaskItemStatusCommand>
    {
        private readonly ITaskItemService _taskItemService;

        public UpdateTaskItemStatusCommandHandler(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        public async Task Handle(UpdateTaskItemStatusCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskItemService.GetByIdAsync(request.Id);
            if (task == null) return;

            task.Status = request.Status;
            await _taskItemService.UpdateAsync(task);
        }
    }
}
