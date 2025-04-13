using FluentValidation;
using TaskManagementApp.BusinessLayer.Features.Mediator.Commands.TaskItemCommands;

namespace TaskManagementApp.BusinessLayer.Validators
{
    public class UpdateTaskItemCommandValidator : AbstractValidator<UpdateTaskItemCommand>
    {
        public UpdateTaskItemCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Geçersiz görev ID.");

          
        }
    }
}
