using FluentValidation;
using TaskManagementApp.BusinessLayer.Features.Mediator.Commands.CommentCommands;

namespace TaskManagementApp.BusinessLayer.Validators
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Yorum içeriği boş olamaz.")
                .MaximumLength(500).WithMessage("Yorum en fazla 500 karakter olabilir.");

            RuleFor(x => x.TaskItemId)
                .GreaterThan(0).WithMessage("Yorum yapılacak görev geçersiz.");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("Yorum sahibi geçersiz.");
        }
    }
}
