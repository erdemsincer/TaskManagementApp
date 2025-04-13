using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApp.BusinessLayer.Features.Mediator.Commands.TaskItemCommands;

namespace TaskManagementApp.BusinessLayer.Validators
{
    public class CreateTaskItemCommandValidator : AbstractValidator<CreateTaskItemCommand>
    {
        public CreateTaskItemCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Görev başlığı boş olamaz.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz.");

            RuleFor(x => x.ProjectId)
                .GreaterThan(0).WithMessage("Proje seçimi zorunludur.");

            RuleFor(x => x.Status)
                .Must(status => new[] { "ToDo", "InProgress", "Done" }.Contains(status))
                .WithMessage("Geçerli bir durum giriniz (ToDo, InProgress, Done)");

            RuleFor(x => x.Priority)
                .Must(priority => new[] { "Low", "Medium", "High" }.Contains(priority))
                .WithMessage("Geçerli bir öncelik giriniz (Low, Medium, High)");
        }
    }
}
