using FluentValidation;
using TaskManagementApp.BusinessLayer.Features.Mediator.Commands.ProjectCommand;

namespace TaskManagementApp.BusinessLayer.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Proje başlığı boş olamaz.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Proje açıklaması boş olamaz.");

            RuleFor(x => x.OwnerUserId)
                .GreaterThan(0).WithMessage("Proje sahibi geçersiz.");
        }
    }
}
