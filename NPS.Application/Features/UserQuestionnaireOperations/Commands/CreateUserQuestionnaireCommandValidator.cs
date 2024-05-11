using FluentValidation;

namespace NPS.Application.Features.UserQuestionnaireOperations.Commands;

public class CreateUserQuestionnaireCommandValidator : AbstractValidator<CreateUserQuestionnaireCommandRequest>
{
    public CreateUserQuestionnaireCommandValidator()
    {
        RuleFor(n => n.Score).NotEmpty();
        RuleFor(n => n.Score).NotNull();

        RuleFor(n => n.UserId).NotEmpty();
        RuleFor(n => n.UserId).NotNull();

        RuleFor(n => n.QuestionnaireId).NotEmpty();
        RuleFor(n => n.QuestionnaireId).NotNull();
    }
}