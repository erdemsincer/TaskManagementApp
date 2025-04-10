using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Commands.TaskItemCommands;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.TaskItemHandlers
{
    public class RemoveTaskItemCommandHandler : IRequestHandler<RemoveTaskItemCommand>
    {
        private readonly ITaskItemService _taskItemService;

        public RemoveTaskItemCommandHandler(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        public async Task Handle(RemoveTaskItemCommand request, CancellationToken cancellationToken)
        {
            var taskItem = await _taskItemService.GetByIdAsync(request.Id);
            if (taskItem != null)
            {
                await _taskItemService.DeleteAsync(taskItem);
            }
        }
    }
}
